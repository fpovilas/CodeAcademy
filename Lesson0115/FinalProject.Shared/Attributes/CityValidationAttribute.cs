using FinalProject.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared.Attributes
{
    public class CityValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string city)
            {
                var isCity = LithuanianCities.City.Contains(city);
                if (!isCity)
                {
                    return new ValidationResult(GetErrorMessage(city));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string city)
        {
            return $"{city} does not pass validation. There is no city in list with this name";
        }


    }
}