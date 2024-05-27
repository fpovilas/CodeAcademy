namespace Task1.Class
{
    internal class Person(string name, int age)
    {
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
