using Task3.Class;

namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            Accept2TypeTs<string, int>.GetType("Labas");
            string? test = null;
            Accept2TypeTs<string, int>.GetType(test);
        }
    }
}
/*
 * Create a Type class that accepts two Type T variables
 * It will have a function GetType with parameter T input, which will print the data type of the input variable.
*/