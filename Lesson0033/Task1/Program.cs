using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            Generic2Type<string, char> generic = new();
            generic.SetT1("Labas");
            generic.SetT2('c');
            generic.Print();
        }
    }
}

/*
 * Generics parameters can be used in more than one e.g. Method<T1,T2>
 * Create a class that accepts two generic type parameters.
 * The class will have two variables that will correspond to those generic parameters.
 * Will have four functions, two of which will be printed in T1 and T2 properties
 * The other two functions will allow you to change the value of T1 and T2 properties.
*/