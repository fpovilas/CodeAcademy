using FinalProject.Shared.Enums;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.DTOs
{
    public class PlaceOfResidenceUpdateDTO
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }

        private readonly string streetCheckRegex = @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž.]+(?:[ \-][A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž.]+)*$";
        private readonly string houseNumRegex = @"^\d+[a-zA-Z]?";
        private readonly string apartmentNumRegex = @"^\d+$";

        public bool Validate()
        {
            // City, Street, HouseNumber, ApartmentNumber
            bool isCity, isStreet, isHouseNum, isApartmentNum;

            isCity = ValidateCity();

            isStreet = ValidateStreet();

            isHouseNum = ValidateHouseNumber();

            isApartmentNum = ValidateApartmentNumber();

            return isCity && isStreet && isHouseNum && isApartmentNum;
        }

        public bool ValidateCity()
            => LithuanianCities.City.Contains(City!);

        public bool ValidateStreet()
            => Regex.IsMatch(Street!, streetCheckRegex);

        public bool ValidateHouseNumber()
            => Regex.IsMatch(HouseNumber!, houseNumRegex);

        public bool ValidateApartmentNumber()
            => Regex.IsMatch(ApartmentNumber!, apartmentNumRegex);
    }
}