namespace Task1.Class
{
    internal class FlightBooking
    {
        private string PassangerName { get; set; }
        private string FlightNumber { get; set; }
        private Dictionary<string, Dictionary<string, List<string>>> GroupFlight { get; set; } = new();
        Dictionary<string, Dictionary<List<string>, string>> CorporateFlight { get; set; } = new();

        public FlightBooking()
        {
            PassangerName = string.Empty;
            FlightNumber = string.Empty;
        }

        public void CreateBooking(string passangerName, string flightNumber)
        {
            PassangerName = passangerName;
            FlightNumber = flightNumber;
        }

        public void CreateBooking(List<string> passangerNames, string flightNumber, string groupName)
        {
            GroupFlight = new()
            {
                {
                    flightNumber, new()
                    {
                        { groupName, passangerNames }
                    }
                }
            };
        }

        public void CreateBooking(string corpName, Dictionary<List<string>, string> employeeAndFlight)
        {
            CorporateFlight = new()
            {
                { corpName, employeeAndFlight }
            };
        }

        public void GetBooking(string type)
        {
            switch (type.ToLower())
            {
                case "individual":
                    Console.WriteLine(PassangerName + " " + FlightNumber);
                    break;
                case "group":
                    foreach(var group in GroupFlight)
                    {
                        Console.WriteLine($"Flight No.: {group.Key}");
                        foreach(var flight in group.Value)
                        {
                            Console.WriteLine($"\t Group: {flight.Key}");
                            foreach(var item in flight.Value)
                            {
                                Console.WriteLine($"\t\t- {item}");
                            }
                        }
                    }
                    break;
                case "corporate":
                    break;
                default:
                    Console.WriteLine("Somthing wrong");
                    break;
            }
        }
    }
}
