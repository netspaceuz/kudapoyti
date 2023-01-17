using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Attributes
{

    public class ImageFileAttribute : ValidationAttribute
    {
        private readonly string[] _extensions = { ".jpg", ".jpeg", ".png", ".gif" };
        private readonly int[] _imageFileHeaders = { 0xFF, 0xD8 };

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file == null)
            {
                return new ValidationResult("No file uploaded");
            }

            if (!_extensions.Contains(Path.GetExtension(file.FileName)))
            {
                return new ValidationResult("Invalid file type");
            }
            return ValidationResult.Success;
        }
    }
}
