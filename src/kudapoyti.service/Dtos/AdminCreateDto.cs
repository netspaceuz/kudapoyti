using kudapoyti.Domain.Entities.Admins;
using kudapoyti.Service.Common.Attributes;
using kudapoyti.Service.Common.Security;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos     
{
    public class AdminCreateDto
    {
        [Required]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "The Title should be minimum 5 and maximum 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required, StrongEmail]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string TelegramLink { get; set; } = string.Empty;

        [Required, PhoneNumber]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required,  StrongPassword]
        public string Password { get; set; } = string.Empty;

        public static implicit operator Admin1(AdminCreateDto accountRegisterDto)
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

