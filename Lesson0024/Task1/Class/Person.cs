namespace Task1.Class
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(string name, int age, int height) : this(name, age)
        {
            Height = height;
        }

        public Person(DateTime birthDay, string name, int age) : this(name, age)
        {
            Birthday = birthDay;
        }
    }
}
