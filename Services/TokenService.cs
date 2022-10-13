using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIFibra.Entities;
using APIFibra.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIFibra.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        
        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }
        
        public string GenerateToken(Administrativo user)
        {
           
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(_config.GetConnectionString("TokenKey"));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Nivel.ToString()),
                    new Claim(ClaimTypes.Name, user.Usuario)
                }),
                
                Expires = DateTime.UtcNow.AddMinutes(50),
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}