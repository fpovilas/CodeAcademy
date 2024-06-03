using FinalProject.Shared.Enums;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.DTOs
{
    public class PlaceOfResidenceDTO
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }

        private readonly string streetCheckRegex = @"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž.]+(?:[ \-][A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž.]+)*$";
        private readonly string houseNumRegex = @"^\d+[a-zA-Z]?";
        private readonly string apartmentNumRegex = @"^\d+$";

        public bool Validate()
        {
            // City, Street, HouseNumber, ApartmentNumber
            var isCity = LithuanianCities.City.Contains(City);
            var isStreet = Regex.IsMatch(Street, streetCheckRegex);
            var isHouseNum = Regex.IsMatch(HouseNumber, houseNumRegex);

            bool isApartmentNum;
            if (ApartmentNumber is not null)
            { isApartmentNum = Regex.IsMatch(ApartmentNumber, apartmentNumRegex); }
            else { isApartmentNum = true; }

            return isCity && isStreet && isHouseNum && isApartmentNum;
        }
    }
}