namespace GettingDataFromAPI.DTO
{
    public class WeatherForecastDTO
    {
            public int queryCost { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public string? resolvedAddress { get; set; }
            public string? address { get; set; }
            public string? timezone { get; set; }
            public float tzoffset { get; set; }
            public string? description { get; set; }
            public required Day[] days { get; set; }

        public class Day
        {
            public string? datetime { get; set; }
            public int datetimeEpoch { get; set; }
            public float temp { get; set; }
            public float feelslike { get; set; }
            public float dew { get; set; }
            public float humidity { get; set; }
            public float precip { get; set; }
            public float precipprob { get; set; }
            public float precipcover { get; set; }
            public string[]? preciptype { get; set; }
            public float snow { get; set; }
            public float snowdepth { get; set; }
            public float windgust { get; set; }
            public float windspeed { get; set; }
            public float winddir { get; set; }
            public float pressure { get; set; }
            public float cloudcover { get; set; }
            public float visibility { get; set; }
            public float solarradiation { get; set; }
            public float solarenergy { get; set; }
            public float uvindex { get; set; }
            public float severerisk { get; set; }
            public string? sunrise { get; set; }
            public int sunriseEpoch { get; set; }
            public string? sunset { get; set; }
            public int sunsetEpoch { get; set; }
            public float moonphase { get; set; }
            public string? conditions { get; set; }
            public string? description { get; set; }
            public string? source { get; set; }
        }
    }
}
