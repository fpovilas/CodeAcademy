using Task1.Interfaces;
using Task3.Interface;

namespace Task1.Class
{
    internal class Carp(string name) : IAnimal, IFish, IWriteable
    {
        private string Name { get; set; } = name;

        public string GetName() => Name;

        public void Eat()
        {
            Console.WriteLine($"{Name} eats organic detritus, aquatic insects, and vegetation.");
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} swims in lakes or swampy waters.");
        }

        public override string ToString() => Name;

        public void WriteToFile(string fileName)
        {
            using StreamWriter writer = new(fileName, true);
            writer.WriteLine(ToString());
        }
    }
}
