namespace Task1.Class
{
    internal class Cat : Animal
    {
        public string Name { get; set; }
        public string Owner { get; set; }

        public Cat(string name, string owner)
        {
            Name = name;
            Owner = owner;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Meow I'm {Name} and my owner is {Owner} Meow");
        }
    }
}
