namespace Task3.Class
{
    internal class Cat
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        public Cat()
        {
            Name = string.Empty;
            Breed = string.Empty;
        }
        public Cat(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello my name is {Name} and I'm {Breed} cat");
        }
    }
}
