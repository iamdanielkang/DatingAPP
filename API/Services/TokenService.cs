using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        // Symmetric encryption is a type of encryption where 1 key is used to encrypt and decrypt
        // electronic information. Can sign and make sure the signature is verified
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            // Symmetric Security Key takes a byte array of the key (Requires encoding)
            // accesses a property from config called TokenKey
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            // Identify what claims will be made inside the token.
            var claims = new List<Claim>
            {
                // Name Id is going to store the user.username
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            // This will sign our token
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject =  new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}