using Task1.Interfaces;

namespace Task1.Class
{
    internal class Bass(string name) : IAnimal, IFish
    {
        private string Name { get; set; } = name;

        public string GetName() => Name;

        public void Eat()
        {
            Console.WriteLine($"{Name} eats worms or other small fish.");
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} swims in lakes.");
        }

        public override string ToString() => Name;
    }
}
