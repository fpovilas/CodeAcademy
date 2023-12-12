using Task3.Class;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Example with Dog, Cat, Hamster Classes
                2. 
                """);
        }

        private static int GetChoice()
        {
            Console.WriteLine("Please enter your choice");
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                return choice;
            }
            return 0;
        }

        private static List<string> ReturnAnimalNames(Dog dog, Cat cat, Hamster hamster)
        {
            List<string> animalNames = new List<string>();
            animalNames.Add(dog.Name);
            animalNames.Add(cat.Name);
            animalNames.Add(hamster.Name);

            return animalNames;
        }

        private static void ReturnAnimals(List<Dog> dogs, List<Cat> cats, List<Hamster> hamsters)
        {
            for(int i = 0; i < 8;  i++)
            {
                dogs.Add(new Dog($"Dog{i}", $"Breed{i}"));
            }

            for (int i = 0; i < 7; i++)
            {
                cats.Add(new Cat($"Cat{i}", $"Breed{i}"));
            }

            for (int i = 0; i < 7; i++)
            {
                hamsters.Add(new Hamster($"Hamster{i}"));
            }
        }

        private static Dictionary<string, int> ReturnAnimalCount(List<Dog> dogs, List<Cat> cats, List<Hamster> hamsters)
        {
            Dictionary<string, int> animalAndCount = new ();
            animalAndCount.Add("Dog", dogs.Count);
            animalAndCount.Add("Cat", cats.Count);
            animalAndCount.Add("Hamster", hamsters.Count);

            return animalAndCount;
        }

        private static void PrintList(List<Dog> dogs)
        {
            Console.WriteLine("Dogs:");
            foreach (Dog dog in dogs)
            {
                Console.WriteLine($"\t- {dog.Name} - {dog.Breed}");
            }
        }

        private static void PrintList(List<Cat> cats)
        {
            Console.WriteLine("Cats:");
            foreach (Cat cat in cats)
            {
                Console.WriteLine($"\t- {cat.Name} - {cat.Breed}");
            }
        }

        private static void PrintList(List<Hamster> hamsters)
        {
            Console.WriteLine("Hamsters:");
            foreach (Hamster hamster in hamsters)
            {
                Console.WriteLine($"\t- {hamster.Name}");
            }
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Dog hela = new("Hela", "Husky Terrier");
                    Cat viskis = new("Viskis", "Siberian");
                    Hamster gelis = new("Gelis");

                    List<string> animalNames = ReturnAnimalNames(hela, viskis, gelis);

                    Console.WriteLine("Animal names: ");
                    foreach (string name in animalNames)
                        Console.WriteLine("\t- " + name);

                    List<Dog> dogs = new List<Dog>();
                    List<Cat> cats = new List<Cat>();
                    List<Hamster> hamsters = new List<Hamster>();
                    ReturnAnimals(dogs, cats, hamsters);

                    Dictionary<string, int> animalAndCount = ReturnAnimalCount(dogs, cats, hamsters);

                    foreach(KeyValuePair<string, int> animalPair in animalAndCount)
                    {
                        Console.WriteLine($"{animalPair.Key} - {animalPair.Value}");
                    }
                    break;
                case 2:
                    
                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }
    }
}