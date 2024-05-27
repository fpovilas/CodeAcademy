using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            #region Variables

            List<int> listOfInts = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            List<int> listOfPosAndNegNums = [0, -1, 2, 3, -10, -55, 100, -5];
            List<Person> listOfPeople = [
                new("Povilas", 50),
                new("Petras", 10),
                new("Ieva", 35),
                new("Kostas", 12),
                new("Konstantinas", 105),
                new("Anastasija", 80)
                ];

            #endregion

            PrintMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    Console.Write("Default list: ");
                    PrintList(listOfInts);

                    Console.Write("Squared list: ");
                    PrintList(listOfInts.Select(num => num * num).ToList());
                    break;
                case 2:
                    Console.Write("Default list: ");
                    PrintList(listOfPosAndNegNums);

                    Console.Write("Only positive value list: ");
                    PrintList(listOfPosAndNegNums.Select(num => num).Where(num => num > 0).ToList());
                    break;
                case 3:
                    Console.Write("Default list: ");
                    PrintList(listOfPosAndNegNums);

                    Console.Write("Only positive value list: ");
                    PrintList(listOfPosAndNegNums.Select(num => num).Where(num => num > 0 && num < 10).ToList());
                    break;
                case 4:
                    Console.Write("Default list: ");
                    PrintList(listOfPosAndNegNums);

                    Console.Write("Ordered ascending: ");
                    PrintList([.. listOfPosAndNegNums.Select(num => num).OrderBy(num => num)]);
                    //PrintList(listOfPosAndNegNums.Select(num => num).OrderBy(num => num).ToList());
                    break;
                case 5:
                    Console.Write("Default list: ");
                    PrintList(listOfPosAndNegNums);

                    Console.Write("Ordered descending: ");
                    PrintList([.. listOfPosAndNegNums.OrderByDescending(num => num)]);
                    //PrintList(listOfPosAndNegNums.Select(num => num).OrderByDescending(num => num).ToList());
                    break;
                case 6:
                    Console.Write("Default list: ");
                    PrintList(listOfPosAndNegNums);

                    Console.Write("Ordered descending: ");
                    Console.WriteLine(listOfPosAndNegNums.Max(num => num));
                    break;
                case 7:
                    List<string> listOfNames = listOfPeople.Select(ppl => ppl.Name).ToList();
                    Console.Write("List of names: ");
                    PrintList(listOfNames);

                    List<int> listOfAges = listOfPeople.Select(ppl => ppl.Age).ToList();
                    Console.Write("List of ages: ");
                    PrintList(listOfAges);
                    break;
                case 8:
                    Console.Write("Default list: ");
                    PrintList(listOfPeople);

                    Console.Write("List ordered by age in descending order: ");
                    PrintList(listOfPeople.Select(ppl => ppl).OrderByDescending(ppl => ppl.Age).ToList());
                    break;
                case 9:
                    Console.Write("Default list: ");
                    PrintList(listOfPeople);

                    Console.Write("List where name starts with letter A: ");
                    PrintList(listOfPeople.Where(ppl => ppl.Name.StartsWith('A')).ToList());
                    break;
                case 10:
                    Console.Write("Default list: ");
                    PrintList(listOfPeople);

                    Console.Write("List where name starts with letter A: ");
                    PrintList(listOfPeople.Select(ppl => ppl).Where(ppl => ppl.Age >= 40).OrderBy(ppl => ppl.Name).ToList());
                    break;
                default:
                    Console.WriteLine($"Wrong choice... {choice}");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.  Return new List<int> with squared values
                2.  Return new List<int> with only positive values
                3.  Return new List<int> with only positive values and < 10
                4.  Return new List<int> ordered in ascending order
                5.  Return new List<int> ordered in descending order
                6.  Return biggest number from List<int>
                --- Task with Person class ---
                7.  Return from List<Person>, List<string> with people names and List<int> with people age
                8.  Return new List<Person> ordered by age in descending order
                9.  Return new List<Person> where name start with letter A
                10. Return new List<Person> where age is more >= 40
                """);
        }

        private static int GetChoice()
        {
            Console.Write("Your choice: ");
            if(int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        private static void PrintList<Type>(List<Type> list)
        {
            for(int i = 0; i < list.Count ;i++)
            {
                if (i < list.Count - 1)
                    Console.Write($"{list[i]}, ");
                else { Console.WriteLine($"{list[i]}."); }
            }
        }
    }
}
/*
 * Create a list with numbers. Create a new list and assign to its value the list returned by the first Select list. The Select method must square each number in the first list.
 * Create a list of positive and negative elements, create a new list from it with LINQ returning only positive numbers.
 * Create a list of positive and negative elements, create a new list from it with LINQ, returning only positive numbers not greater than 10.
 * Create a list of numbers and use LINQ to sort them in ascending order.
 * Create a list of numbers and use LINQ to sort them in descending order.
 * Find the largest item in the list of numbers using LINQ.
 * Create a Person class with Name and Age parameters, create a list of these objects.
 ** Create a new list with LINQ taking only people's names, the other list from age only.
 ** Sort the list in descending order of age.
 ** Create a new list of people whose names start with the letter A.
 ** Create a new list of people aged 40+ and sort it by name.
*/