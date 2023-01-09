using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Attributes;
using kudapoyti.Service.Common.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos
{
    public class UpdateCreateDto
    {
        [MaxLength(50), MinLength(5)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(25), MinLength(3), StrongEmail]
        public string Email { get; set; } = string.Empty;

        
        public string TelegramLink { get; set; } = string.Empty;

        [ PhoneNumber]
        public string PhoneNumber { get; set; } = string.Empty;

      
        public string Description { get; set; } = string.Empty;

        [ MinLength(8), StrongPassword]
        public string Password { get; set; } = string.Empty;

        public static implicit operator Admin1(UpdateCreateDto accountRegisterDto)
        {
            var hasherResult = PasswordHasher.Hash(accountRegisterDto.Password);
            return new Admin1()
            {
                FullName = accountRegisterDto.FullName,
                Email = accountRegisterDto.Email,
                TelegramLink = accountRegisterDto.TelegramLink,
                PhoneNumber = accountRegisterDto.PhoneNumber,
                Description = accountRegisterDto.Description,
                Salt = hasherResult.salt,
                PasswordHash = hasherResult.passwordHash,
            };
        }
    }
}
