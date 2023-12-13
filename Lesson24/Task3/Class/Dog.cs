namespace Task3.Class
{
    internal class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        public Dog()
        {
            Name = string.Empty;
            Breed = string.Empty;
        }
        public Dog(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello my name is {Name} and I'm {Breed}");
        }
    }
}
