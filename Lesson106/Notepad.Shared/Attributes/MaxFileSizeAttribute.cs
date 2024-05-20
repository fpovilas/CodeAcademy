using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Notepad.Shared.Attributes
{
    public class MaxFileSizeAttribute(int maxFileSize) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Maximum allowed file size is {maxFileSize / 1e6} MB";
        }
    }
}