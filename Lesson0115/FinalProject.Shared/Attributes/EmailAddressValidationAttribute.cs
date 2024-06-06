using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.Attributes
{
    public class EmailAddressValidationAttribute : ValidationAttribute
    {
        private readonly string emailCheck = @"^(?i)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string emailAddress)
            {
                var isEmailAddress = Regex.IsMatch(emailAddress, emailCheck);
                if (!isEmailAddress)
                {
                    return new ValidationResult(GetErrorMessage(emailAddress));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string emailAddress)
        {
            return $"{emailAddress} does not pass validation.";
        }


    }
}