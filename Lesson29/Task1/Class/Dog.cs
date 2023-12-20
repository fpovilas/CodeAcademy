namespace Task1.Class
{
    internal class Dog : Animal
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        public Dog(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Woof I'm {Name} and my breed is {Breed} Woof");
        }
    }
}
