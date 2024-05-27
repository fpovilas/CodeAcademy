namespace Task1.Class
{
    internal class Person
    {
        private string name = string.Empty;
        private int age;

        protected string Name
        {
            get => name;
            private set { name = value; }
        }

        protected int Age
        {
            get => age;
            private set { age = value; }
        }

        public void SetAge(int age)
        { Age = age; }

        public void SetName(string name)
        { Name = name; }

        protected void PrintInfo()
        {
            Console.Write($"{Name} is {Age} y/o ");
        }
    }
}
