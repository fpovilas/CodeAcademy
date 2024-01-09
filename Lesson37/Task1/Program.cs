namespace Task1
{
    internal class Program
    {
        private delegate string PersonInfo(string firstName, string lastName, int age);
        private delegate int Numbers(int a, int b);
        private delegate List<int> EveryOtherNumber(List<int> list, int step);
        private delegate string? GetMethodType<T>(T type);

        static void Main()
        {
            PrintMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    PersonInfo personInfo = new(GetInfo);
                    Console.WriteLine(personInfo("Povilas", "Frišmantas", 26));
                    break;
                case 2:
                    Numbers numbers = new(GetTwoNumbers);
                    Console.WriteLine($"5 + 6 = {numbers(5,6)}");
                    break;
                case 3:
                    List<int> listOfNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
                    EveryOtherNumber everyOtherNumber = new(EveryOtherStep);
                    List<int> newListOfNumbers = everyOtherNumber(listOfNumbers, 3);
                    List<int> newListOfNumbers2 = everyOtherNumber(listOfNumbers, 2);
                    List<int> newListOfNumbers3 = everyOtherNumber(listOfNumbers, 5);

                    Print(PrintList, 1, listOfNumbers);
                    Print(PrintList, 3, newListOfNumbers);
                    Print(PrintList, 2, newListOfNumbers2);
                    Print(PrintList, 5, newListOfNumbers3);
                    break;
                case 4:
                    string val = "value";
                    GetMethodType<string> getMethodType = new(GetType);
                    Console.WriteLine(GetType(val));

                    sbyte num = 0;
                    GetMethodType<int> getMethodType1 = new(GetType);
                    Console.WriteLine(GetType(num));
                    break;
                default:
                    Console.WriteLine($"Wrong choice... ({choice})");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Delegate that points to a method with a string return type and three parameters firstName, lastName and age.
                2. Delegate that points to a method with an int return type and two parameters number1 and number2.
                3. Delegate that points to a method with List<int> return type and two parameters List<int> and int step. Return every other step element from List
                4. Delegate that points to the GetType<T> method with return type string and parameter T element, the method returns the data type of the element variable.
                """);
        }

        private static void PrintList(List<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(i < list.Count - 1)
                    Console.Write(list[i] + ", ");
                else Console.WriteLine(list[i] + ".");

            }
        }

        private static void Print(Action<List<int>> func, int step, List<int> list)
        {
            Console.Write($"Steps {step}. ");
            func(list);
        }

        private static int GetChoice()
        {
            Console.Write("Your choice: ");
            if(int.TryParse(Console.ReadLine(), out var choice))
                return choice;
            else return 0;
        }

        private static string GetInfo(string firstName, string lastName, int age) => $"{firstName} {lastName} is {age} y/o";

        private static int GetTwoNumbers(int x, int y) => x + y;

        private static List<int> EveryOtherStep(List<int> numbers, int step)
        {
            List<int> result = [];

            for(int i = 0; i < numbers.Count; i+=step)
            {
                result.Add(numbers[i]);
            }

            return result;
        }

        private static string? GetType<T>(T type) => type?.GetType().Name;
    }
}
/*
 * Create a delegate that points to a method with a string return type and three parameters firstName, lastName and age. Call the delegate method.
 * Create a delegate that points to a method with an int return type and two parameters number1 and number2. Call the delegate method.
 * Create a delegate that points to a method with List<int> return type and two parameters List<int> and int step, the essence of the method will be to return the next element (every next element is specified by the "step" parameter). Call the delegate method.
 * Create a delegate that points to the GetType<T> method with return type string and parameter T element, the method returns the data type of the element variable. Call the delegate method.
*/