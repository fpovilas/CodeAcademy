namespace Task2.Class
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        public Customer(string name, string address,
                    string city, string region)
        {
            Name = name;
            Address = address;
            City = city;
            Region = region;
        }
    }
}
