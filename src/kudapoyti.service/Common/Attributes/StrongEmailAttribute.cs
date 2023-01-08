using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StrongEmailAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string email)
            {
                if (IsValidEmail(email))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Invalid email address");
            }
            return new ValidationResult("Email address must be filled");
        }
        private bool IsValidEmail(string email)
        {
            if (email is null) return false;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (regex.Match(email.ToString()!).Success)
                return true;
            return false;
        }
    }
}
