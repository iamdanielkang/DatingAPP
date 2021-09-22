using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;


// The whole point of interfaces is a contract between itself and 
// any class that implements it
// No implementation logic
namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);


    }
}