using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.Attributes
{
    public class StreetValidationAttribute : ValidationAttribute
    {
        private readonly string streetCheckRegex = @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž.]+(?:[ \-][A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž.]+)*$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string street)
            {
                var isStreet = Regex.IsMatch(street, streetCheckRegex);
                if (!isStreet)
                {
                    return new ValidationResult(GetErrorMessage(street));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string street)
        {
            return $"{street} does not pass validation. There is no street in list with this name";
        }


    }
}