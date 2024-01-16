using Task1.Class;
using Task1.Comparer;
using Task1.Interfaces;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            Bass redBass = new("Red Bass");
            redBass.Swim();
            redBass.Eat();

            Separator();

            Carp hugeCarp = new("Carp The Huge");
            hugeCarp.Swim();
            hugeCarp.Eat();

            Separator();

            Cat whiskersTheCat = new("Whiskers", true);
            whiskersTheCat.Eat();
            whiskersTheCat.GiveBirth();

            Separator();

            Dog boxyTheDog = new("Boxy", false);
            boxyTheDog.Eat();
            boxyTheDog.GiveBirth();

            Separator();

            List<IAnimal> animals = [redBass, hugeCarp, whiskersTheCat, boxyTheDog];
            List<IMammal> mammals = [whiskersTheCat, boxyTheDog];
            List<IFish> fishes = [redBass, hugeCarp];

            PrintText("IAnimal list: ");
            PrintList(animals);

            Separator();

            PrintText("IMammal list: ");
            PrintList(mammals);

            Separator();

            PrintText("IFish list: ");
            PrintList(fishes);

            Separator();

            AnimalComparer animalComparer = new ();
            List<Bass> basses = [new("Bass The Mighty"), new("Cruel Bass"), new("A Friendly Bass")];
            List<Carp> carps = [new("Huge Carp"), new("Baby Carp"), new("Carp The Great")];
            List<Cat> cats = [new("Whisky", true), new("Pouncer", false), new("Agar", true)];
            List<Dog> dogs = [new("Howler", false), new("Hela", true), new("Goofy", false)];

            PrintText("Not sorted classes", true);
            PrintList(basses);
            PrintList(carps);
            PrintList(cats);
            PrintList(dogs);

            Separator();

            PrintText("Sorted classes", true);

            basses.Sort(animalComparer);
            carps.Sort(animalComparer);
            cats.Sort(animalComparer);
            dogs.Sort(animalComparer);

            PrintList(basses);
            PrintList(carps);
            PrintList(cats);
            PrintList(dogs);
        }

        private static void Separator()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        private static void PrintList<Type>(List<Type> list)
        {
            for(int i =0; i < list.Count; i++)
            {
                if (i < list.Count - 1)
                    Console.Write($"{list[i]}, ");
                else Console.WriteLine($"{list[i]}.");
            }
        }

        private static void PrintText(string text, bool printAsList = false)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (printAsList) { Console.WriteLine(text); }
            else { Console.Write(text); }
            Console.ResetColor();
        }
    }
}
