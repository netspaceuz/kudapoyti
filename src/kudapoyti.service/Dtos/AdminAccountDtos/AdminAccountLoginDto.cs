using kudapoyti.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Dtos.Accounts;

public class AdminAccountLoginDto
{
    [Required, StrongEmailAttribute]
    public string Email { get; set; } = string.Empty;

    [Required, StrongPasswordAttribute]
    public string Password { get; set; } = string.Empty;
}
