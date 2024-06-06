using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.Attributes
{
    public class NameValidationAttribute : ValidationAttribute
    {
        private readonly string nameAndLastNameCheck = @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž]{2,50}$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string name)
            {
                var isName = Regex.IsMatch(name, nameAndLastNameCheck);
                if (!isName)
                {
                    return new ValidationResult(GetErrorMessage(name));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string name)
        {
            return $"{name} does not pass validation. It should be between 2 and 50 Lithuanian alphabetical characters";
        }
    }
}