using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.Attributes
{
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        private readonly string phoneNumberCheck = @"^3706.*\d{7}$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string phoneNumber)
            {
                var isPhoneNumber = Regex.IsMatch(phoneNumber, phoneNumberCheck);
                if (!isPhoneNumber)
                {
                    return new ValidationResult(GetErrorMessage(phoneNumber));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string phoneNumber)
        {
            return $"{phoneNumber} does not pass validation. It has to be formatted like 3706XXXXXXX";
        }


    }
}