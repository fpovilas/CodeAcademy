using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.Attributes
{
    public class HouseNumberValidationAttribute : ValidationAttribute
    {
        private readonly string houseNumRegex = @"^\d+[a-zA-Z]?";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string houseNum)
            {
                var isHouseNum = Regex.IsMatch(houseNum, houseNumRegex);
                if (!isHouseNum)
                {
                    return new ValidationResult(GetErrorMessage(houseNum));
                }
            }

            return ValidationResult.Success;
        }

        private static string GetErrorMessage(string houseNum)
        {
            return $"{houseNum} does not pass validation.";
        }


    }
}