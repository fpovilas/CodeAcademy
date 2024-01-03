using System;
using Task3.Class;

namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            Generic2Types<string, byte> generic2Types = new("Tekstas", 1);

            ShowValues(generic2Types);

            ShowValues(0.567M, 'P');
        }

        public static void ShowValues<T>(T t)
        {
            Console.WriteLine(t);
        }

        public static void ShowValues<T1, T2>(T1 t1, T2 t2)
        {
            Console.WriteLine($"TypeOne is {t1?.GetType().Name} value: {t1}\n"
                              + $"TypeTwo is {t2?.GetType().Name} value: {t2}");
        }
    }
}
/*
 * Type T parameters can be specified in more than one, e.g. ShowValues<T1, T2>
 * Create a function that asks for 2 generic types
 * Takes 2 variables via parameters, one of the first generic type, the second of the second generic type
 * They are both printed to the console.
 * 
 * When calling these functions, pass different types.
*/