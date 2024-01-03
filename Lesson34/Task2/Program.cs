using Task2.Class;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            GenericClass<int> genericClass = new([1, 2, 3]);

            genericClass.PrintList();

            int[] numbers = genericClass.ConvertToArray();

            Console.WriteLine(numbers);

            genericClass.Add(1);
            genericClass.PrintList();

            genericClass.Remove(1);
            genericClass.PrintList();

            genericClass.AddList(new([1, 2, 3]));
            genericClass.PrintList();

            genericClass.RemoveByIndex(0);
            genericClass.PrintList();

            genericClass.RemoveAllDuplicates(3);
            genericClass.PrintList();

            Console.WriteLine(Task3.Program.CheckIfNull(genericClass));
        }
    }
}
/* 
 * Create a generic class with a type T list inside.
 * There must be features:
 *
 ** Print the list
 ** Function that returns a list converted to an array;
 ** A function that adds a member to the list;
 ** Function that adds a list of members to the list;
 ** A function that deletes an item in a list;
 ** A function that deletes an item in a list by index;
 ** A function that deletes all relevant items in a list (e.g. deletes all twos);
 */
