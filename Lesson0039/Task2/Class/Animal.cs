namespace Task2.Class
{
    internal class Animal(string name, int age)
    {
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
