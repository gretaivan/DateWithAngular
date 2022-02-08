using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiContoller
    {
        private readonly DataContext _context; 
           public AccountController(DataContext context){
               _context = context; 
           } 

           [HttpPost("register")]
           public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDto){

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

               return user; 
           }

           [HttpPost("login")]
           public async Task<ActionResult<AppUser>> Login(LoginDTO loginDto){
               var user = await _context.Users.SingleOrDefaultAsync( x => x.Username == loginDto.Username);

               if(user == null) return Unauthorized("Invalid username");

               using var hmac = new HMACSHA512(user.PaswordSalt);

               var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

               for(int i = 0; i < computedHash.Length; i++){
                   if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password"); 
               }
               return user; 
           }

           private async Task<bool> UserExists(string username){
               return await _context.Users.AnyAsync(x => x.Username == username.ToLower()); 
           }
    }
}