using Task2.Class;
using Task3.Comparer;

namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            AudiCar audiA3 = new(false, "Audi A3", 40);
            AudiCar audiA6 = new(false, "Audi A6", 50);
            AudiCar audiQ6 = new(true, "Audi Q6", 45);

            List<AudiCar> audiCars = [audiA3, audiA6, audiQ6];
            AudiCarComparer audiComparer = new();
            PrintList(audiCars);
            
            Separator();

            audiCars.Sort(audiComparer);
            PrintList(audiCars);

            Separator();

            List<BmwCar> bmwCars = [
                new(true, "BMW x5", 60),
                new(false, "BMW E36", 25),
                new(true, "BMW x7", 60),
                new(false, "BMW E46", 40)
            ];
            BmwCarComparer bmwCarComparer = new();
            PrintList(bmwCars);

            Separator();

            bmwCars.Sort(bmwCarComparer);
            PrintList(bmwCars);
        }

        private static void PrintList<Type>(List<Type> cars)
        {
            foreach(Type car in cars)
            {
                Console.WriteLine(car?.ToString());
            }
        }

        private static void Separator()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
