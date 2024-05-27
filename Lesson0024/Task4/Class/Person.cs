namespace Task4.Class
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Address = new Address();
        }

        public void SetAddress(string city, string street)
        {
            Address.City = city;
            Address.Street = street;
        }

        public string GetInformation()
        { return $"{Name} is {Age} old and lives in {Address.Street},{Address.City}"; }
    }
}
