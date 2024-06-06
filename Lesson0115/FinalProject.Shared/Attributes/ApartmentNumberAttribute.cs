using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.Attributes
{
    public class ApartmentNumberAttribute : ValidationAttribute
    {
        private readonly string apartmentNumRegex = @"^\d+$";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string apartmentNumber)
            {
                bool isApartmentNum;
                if (apartmentNumber is not null)
                { isApartmentNum = Regex.IsMatch(apartmentNumber, apartmentNumRegex); }
                else { isApartmentNum = true; }

                if (!isApartmentNum)
                {
                    return new ValidationResult(GetErrorMessage(apartmentNumber!));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string apartmentNumber)
        {
            return $"{apartmentNumber} does not pass validation.";
        }


    }
}