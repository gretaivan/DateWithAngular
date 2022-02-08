using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Services.TokenService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiContoller
    {
        private readonly DataContext _context;
        private readonly ITokenCreator _token;

    public AccountController(DataContext context, ITokenCreator token){
               _context = context; 
               _token = token; 
           } 

           [HttpPost("register")]
           public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto){

               if(await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            //    using statement guarantees that we are going to dispose the class once finished
               using var hmac = new HMACSHA512(); 
               var user = new AppUser{
                   Username = registerDto.Username.ToLower(),
                   PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                   PaswordSalt = hmac.Key
               };
                
                // track in entity framework
               _context.Users.Add(user); 
               // save it to the database 
               await _context.SaveChangesAsync();

               return new UserDTO{
                   Username = user.Username,
                   Token = _token.CreateToken(user)
               }; 
           }

           [HttpPost("login")]
           public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto){
               var user = await _context.Users.SingleOrDefaultAsync( x => x.Username == loginDto.Username);

               if(user == null) return Unauthorized("Invalid username");

               using var hmac = new HMACSHA512(user.PaswordSalt);

               var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

               for(int i = 0; i < computedHash.Length; i++){
                   if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password"); 
               }
               return new UserDTO{
                   Username = user.Username, 
                   Token = _token.CreateToken(user)
               }; 
           }

           private async Task<bool> UserExists(string username){
               return await _context.Users.AnyAsync(x => x.Username == username.ToLower()); 
           }
    }
}