using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            List<int> list = [1, 2, 3];

            GenericClass<int> generic = new(list);

            int findExactMatch = generic.FindExactMatch(2);

            int findExactMatchWithDefault = generic.FindExactMatchWithDefault(3);

            bool checkIfExists = generic.CheckIfExists(1);

            Console.WriteLine($"{findExactMatch} - {findExactMatchWithDefault} - {checkIfExists}");

            Console.WriteLine(Task3.Program.CheckIfNull(list));
        }
    }
}
/*
 * Create a generic class with a type T Read Only list (variables are assigned at initialization and cannot be changed). The list of values to initialize the list must come through the constructor.
 * There must be features:
 ** Print the list
 ** Function that returns a list converted to an array;
 ** A function that finds and returns ONE match in a list. If more or less than one is found it must throw an error;
 ** A function that finds and returns one match in a list, BUT if it doesn't find one, returns the default value of that data type. If it finds more than 1 then it throws an error;
 ** A function that checks whether a variable of the specified value exists in the list and returns a value of type bool corresponding to the search result;
 */
