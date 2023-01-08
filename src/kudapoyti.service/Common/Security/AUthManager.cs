using kudapoyti.Service.Dtos.AccountDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
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
        public string GenerateToken(UserValidateDto validUser)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, validUser.Email),
                new Claim(ClaimTypes.Role, validUser.UserRole.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_config["Issure"], _config["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string GenerateToken(Domain.Entities.Admins.Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
