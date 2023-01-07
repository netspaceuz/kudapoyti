using kudapoyti.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MaxLength(50), MinLength(5)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(25), MinLength(3)]
        public string Email { get; set; } = string.Empty;

        public string TelegramLink { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required, MinLength(8)] /*StrongPassword*/
        public string Password { get; set; } = string.Empty;

        public static implicit operator Admin(AccountRegisterDto accountRegisterDto)
        {
            return new Admin()
            {
                FullName = accountRegisterDto.FullName,
                Email = accountRegisterDto.Email,
                TelegramLink = accountRegisterDto.TelegramLink,
                PhoneNumber = accountRegisterDto.PhoneNumber,
            };
        }
    }
}

