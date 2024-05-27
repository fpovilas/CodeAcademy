using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            string? nullString = null;
            string emptyString = string.Empty;

            Validation<string> validationNull = new(nullString);
            validationNull.Validate();

            Validation<string> validationEmpty = new(emptyString);
            validationEmpty.Validate();
        }
    }
}
/*
 * Create a generic class Validation that has a function called Validate
 * The purpose of the validate function would be to check whether the passed
 * parameter is null If it is null it will throw an error.
*/