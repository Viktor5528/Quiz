using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataLayer.Entity;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace LegalActionPlatform.Account.Services.Implementation.Services
{
    public class JWTTokenService : ITokenService
    {
        
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login),
                   
            };

            var jwt = new JwtSecurityToken
            (
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10000)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("qwertyqwertyqwertyqwertyqwerty")), SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}