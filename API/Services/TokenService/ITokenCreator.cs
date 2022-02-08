using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Services.TokenService
{
    public interface ITokenCreator
    {
        string CreateToken(AppUser user);
    }
}