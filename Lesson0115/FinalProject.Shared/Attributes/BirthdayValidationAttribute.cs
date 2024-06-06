using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared.Attributes
{
    public class BirthdayValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly birthday)
            {
                var isBirthday = birthday <= DateOnly.FromDateTime(DateTime.Now);
                if (!isBirthday)
                {
                    return new ValidationResult(GetErrorMessage(birthday));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(DateOnly birthday)
        {
            return $"{birthday} does not pass validation. You can not be younger that current date";
        }
    }
}