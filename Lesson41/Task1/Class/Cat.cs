using Task1.Interfaces;

namespace Task1.Class
{
    internal class Cat(string name, bool isFemale) : IAnimal, IMammal
    {
        private string Name { get; set; } = name;
        private bool IsFemale { get; set; } = isFemale;

        public string GetName() => Name;
        public bool GetIsFemale() => IsFemale;

        public void Eat()
        {
            Console.WriteLine($"{Name} eating it's food.");
        }

        public void GiveBirth()
        {
            if (IsFemale)
            {
                Console.WriteLine($"{Name} gave birth to {GenerateRandom.GetRandomNum()} kittens");
            }
            else { Console.WriteLine($"{Name} cannot give birth to kittens. It is a male"); }
        }

        public override string ToString() => $"{Name} is {(IsFemale ? "female" : "male")}";
    }
}
