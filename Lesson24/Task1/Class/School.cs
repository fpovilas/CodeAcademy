namespace Task1.Class
{
    internal class School
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int StudentNumber { get; set; }

        public School(string name, string city)
        {
            Name = name;
            City = city;
        }

        public School(string name, string city, int studentNumber) : this(name, city)
        {
            StudentNumber = studentNumber;
        }
    }
}
