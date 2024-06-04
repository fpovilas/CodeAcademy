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
            if (City is not null)
            { isCity = LithuanianCities.City.Contains(City); }
            else { isCity = true; }

            if (Street is not null)
            { isStreet = Regex.IsMatch(Street, streetCheckRegex); }
            else { isStreet = true; }

            if (HouseNumber is not null)
            { isHouseNum = Regex.IsMatch(HouseNumber, houseNumRegex); }
            else { isHouseNum = true; }

            if (ApartmentNumber is not null)
            { isApartmentNum = Regex.IsMatch(ApartmentNumber, apartmentNumRegex); }
            else { isApartmentNum = true; }

            return isCity && isStreet && isHouseNum && isApartmentNum;
        }
    }
}