using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MultiProjectStructure.BusinessLogic.Attributes
{
    public class AllowedExtensionsAttribute(string[] extensions) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            if (value is List<IFormFile> files)
            {
                foreach (var item in files)
                {
                    var extension = Path.GetExtension(item.FileName);
                    if (!extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(GetErrorMessage() + $" {item.FileName}");
                    }
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage()
        {
            return $"This photo extension is not supported!";
        }
    }
}