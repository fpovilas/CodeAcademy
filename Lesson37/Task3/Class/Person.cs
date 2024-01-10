namespace Task3.Class
{
    internal class Person(string name, int age)
    {
        private string Name { get; set; } = name;
        private int Age { get; set; } = age;

        public void SetName(string name) => Name = name;

        public void SetAge(int age) => Age = age;

        public string GetName() => Name;

        public int GetAge() => Age;
    }
}
