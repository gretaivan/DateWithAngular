using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiContoller
    {
        private readonly DataContext _context; 
           public AccountController(DataContext context){
               _context = context; 
           } 

           [HttpPost("register")]
           public async Task<ActionResult<AppUser>> Register(string username, string password){
            //    using statement guarantees that we are going to dispose the class once finished
               using var hmac = new HMACSHA512(); 
               var user = new AppUser{
                   Username = username,
                   PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                   PaswordSalt = hmac.Key
               };
                
                // track in entity framework
               _context.Users.Add(user); 
               // save it to the database 
               await _context.SaveChangesAsync();

               return user; 
           }

    }
}