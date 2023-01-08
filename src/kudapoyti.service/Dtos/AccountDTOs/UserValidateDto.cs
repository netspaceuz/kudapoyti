using kudapoyti.Service.Common.Attributes;
using kudapoyti.Service.Enums;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos.AccountDTOs
{
    public class UserValidateDto
    {
        [StrongEmail]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public UserRole UserRole { get; set; }

    }
}
