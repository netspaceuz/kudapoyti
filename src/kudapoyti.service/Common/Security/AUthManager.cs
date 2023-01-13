using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Helpers;
using kudapoyti.Service.Dtos.AccountDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Security
{
    public class AUthManager : IAuthManager
    {
        private readonly IConfiguration _config;
        public AUthManager(IConfiguration configuration)
        {
            _config = configuration.GetSection("Jwt");
        }
        public string GenerateToken(dynamic admin)
        {
            if(admin.GetType() == typeof(UserValidateDto))
            {
                admin = (Admin1)admin;
            };
            var claims = new[]
        {
            new Claim(ClaimTypes.Email, admin.Email),
            new Claim(ClaimTypes.Name,admin.FullName),
            new Claim(ClaimTypes.Role, admin.Role.ToString())
        };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
                signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenDescriptor);
        }
    }
}
