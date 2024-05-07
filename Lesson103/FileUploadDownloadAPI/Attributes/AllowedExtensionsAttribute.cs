using System.ComponentModel.DataAnnotations;

namespace FileUploadDownloadAPI.Attributes
{
    public class AllowedExtensionsAttribute(string[] extensions) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if(!extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
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