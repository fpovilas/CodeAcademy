using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            int[] sortAccending;
            int[] sortDescending;
            int[] startingArray;
            int[] endingArray;

            #endregion

            PrintMenu();
            GetChoice(out string? choice);

            switch (choice)
            {
                case "1":
                case "3.1":
                    sortAccending = new int[] { 1, 4, 2, 3, 6 };

                    Console.Write("Array before sort: ");
                    foreach (int num in sortAccending)
                    {
                        Console.Write($"{num} ");
                    }

                    sortAccending = SortAscending(sortAccending);

                    Console.Write("\nArray after sort: ");
                    foreach (int num in sortAccending)
                    {
                        Console.Write($"{num} ");
                    }
                    break;
                case "2":
                case "3.2":
                    sortDescending = new int[] { 1, 4, 2, 3, 6 };

                    Console.Write("Array before sort: ");
                    foreach (int num in sortDescending)
                    {
                        Console.Write($"{num} ");
                    }

                    sortDescending = SortDescending(sortDescending);

                    Console.Write("\nArray after sort: ");
                    foreach (int num in sortDescending)
                    {
                        Console.Write($"{num} ");
                    }
                    break;
                case "3":
                case "3.3":
                    startingArray = new int[] { 1, 2, 3 };

                    Console.Write(nameof(startingArray) + " : ");
                    for(int i = 0; i < startingArray.Length; i++)
                    { Console.Write(startingArray[i] + " "); }

                    endingArray = AddElementToArray(startingArray, 3);
                    Console.Write("\n" + nameof(endingArray) + " : ");
                    for(int i = 0; i < endingArray.Length; i++)
                    { Console.Write(endingArray[i] + " "); }

                    break;
                case "4":
                case "3.4":
                    startingArray = new int[] { 1, 2, 3 };

                    Console.Write(nameof(startingArray) + " : ");
                    for(int i = 0; i < startingArray.Length; i++)
                    { Console.Write(startingArray[i] + " "); }

                    endingArray = RemoveElementFromArray(startingArray, 3);
                    Console.Write("\n" + nameof(endingArray) + " : ");
                    for(int i = 0; i < endingArray.Length; i++)
                    { Console.Write(endingArray[i] + " "); }

                    break;
                default:
                    Console.WriteLine("There is only 3 tasks!");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                3.1 Sort array in ascending order
                3.2 Sort array in descending order
                3.3 Add element to array
                3.4 Remove Element from array
                """);
        }

        private static void GetChoice(out string? choice)
        {
            Console.Write("Please enter your choice: ");
            choice = Console.ReadLine();
        }

        private static int[] SortAscending(int[] sortAccending)
        {
            for(int i = 0; i < sortAccending.Length; i++)
            {
                for(int j = i;  j < sortAccending.Length; j++)
                {
                    int temp;
                    if (sortAccending[i] < sortAccending[j])
                    {
                        temp = sortAccending[i];
                        sortAccending[i] = sortAccending[j];
                        sortAccending[j] = temp;
                    }
                }
            }
            return sortAccending;
        }

        private static int[] SortDescending(int[] sortDescending)
        {
            for (int i = 0; i < sortDescending.Length; i++)
            {
                for (int j = i; j < sortDescending.Length; j++)
                {
                    int temp;
                    if (sortDescending[i] > sortDescending[j])
                    {
                        temp = sortDescending[i];
                        sortDescending[i] = sortDescending[j];
                        sortDescending[j] = temp;
                    }
                }
            }
            return sortDescending;
        }

        private static int[] AddElementToArray(int[] array, int element)
        {
            int[] newArray = new int[array.Length + 1];

            for(int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[array.Length] = element;

            return newArray;
        }

        private static int[] RemoveElementFromArray(int[] array, int element)
        {
            bool containsElement = false;
            int[] newArray = new int[array.Length - 1];

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                    containsElement = true;
            }

            if(containsElement)
            {
                for(int i = 0;i < array.Length; i++)
                {
                    if (array[i] == element)
                        array[i] = 0;
                }

                int tracker = 0;

                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 0)
                    {
                        newArray[tracker] = array[i];
                        tracker++;
                    }
                }
            }

            return newArray;
        }
    }
}