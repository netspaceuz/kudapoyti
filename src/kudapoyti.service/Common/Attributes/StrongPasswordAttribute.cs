﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StrongPasswordAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("Password can not be null!");
            else
            {
                string password = value.ToString()!;
                if (password.Length < 8)
                    return new ValidationResult("Password must be at least 8 characters!");
                if (password.Length > 30)
                    return new ValidationResult("Password must be less than 50 characters!");

                var result = IsStrong(password);

                if (result.IsValid is false) return new ValidationResult(result.Message);

                return ValidationResult.Success;
            }
        }

        public (bool IsValid, string Message) IsStrong(string password)
        {
            bool isDigit = password.Any(x => char.IsDigit(x));
            bool isUpper = password.Any(x => char.IsUpper(x));
            if (!isUpper)
                return (IsValid: false, Message: "Password must be at least one upper letter!");
            if (!isDigit)
                return (IsValid: false, Message: "Password must be at least one digit!");

            return (IsValid: true, Message: "Password is strong");
        }
    }
}
