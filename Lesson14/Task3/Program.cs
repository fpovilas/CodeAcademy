using System.Diagnostics.Metrics;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string choice;
            int[,] valueArray;
            int maxValueInArray;
            int[,] symetricalArray;
            int numberOfAnimals;
            string[,] tableOfAnimals;

            #endregion

            PrintMenu();

            choice = GetChoice();

            switch (choice)
            {
                case "3.1":
                    valueArray = new int[,]{
                                {1, 2, 3},
                                {4, 20, 6},
                                {7, 8, 9}};

                    maxValueInArray = GetMaxValue(valueArray);

                    Console.WriteLine(maxValueInArray);
                    break;
                case "3.2":
                    // Does not work for non symetricals
                    symetricalArray = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

                    if(isSymetrical(symetricalArray))
                        Console.WriteLine("Array is symetrical");
                    else
                        Console.WriteLine("Array is not symetrical");
                    break;
                case "3.3":
                    Console.Write("Please enter number of Animals: ");
                    if(int.TryParse(Console.ReadLine(), out numberOfAnimals))
                    {
                        tableOfAnimals = CreateTableOfAnimals(numberOfAnimals);

                        for(int i = 0; i < tableOfAnimals.GetLength(0); i++)
                        {
                            for(int j = 0; j < tableOfAnimals.GetLength(1); j++)
                            {
                                Console.Write($"{tableOfAnimals[i, j],15}");
                            }
                            Console.WriteLine();
                        }
                    }
                    else { Console.WriteLine("You entered not a integer num."); }
                     break;
                case "3.4":
                    DrawStars();
                    break;
                default:
                    Console.WriteLine("There is only 4 tasks or wrong choice");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                3.1 Find max value in 2D array
                3.2 Check if array is symmetrical
                3.3 Table of animals
                3.4 Draw plus from stars
                """);
        }

        private static string GetChoice()
        {
            Console.Write("Please eneter your choice: ");
            return Console.ReadLine();
        }

        private static int GetMaxValue(int[,] valueArray)
        {
            int maxValue = int.MinValue;
            int[] valueArray1D = Get1DArray(valueArray);

            for(int i = 0; i < valueArray1D.Length; i++)
            {
                if (maxValue < valueArray1D[i])
                    maxValue = valueArray1D[i];
            }

            return maxValue;
        }

        private static int[] Get1DArray(int[,] valueArray)
        {
            int[] newArray = new int[valueArray.GetLength(0) * valueArray.GetLength(1)];
            int counter = 0;

            for(int i = 0; i < valueArray.GetLength(0); i++)
            {
                for (int j = 0; j < valueArray.GetLength(1); j++)
                {
                    newArray[counter] = valueArray[i, j];
                    counter++;
                }
            }

            return newArray;
        }

        private static bool isSymetrical(int[,] valueArray)
        {
            int symmetricalH = 0;
            int symmetricalV = 0;
            bool symetrical = false;

            // Checking if it symmetrical Vertically
            for (int i = 0; i < valueArray.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < Math.Ceiling((decimal)valueArray.GetLength(1) / 2); j++)
                {
                    if (valueArray[i, j] == valueArray[valueArray.GetLength(0) - i - 1, valueArray.GetLength(1) - j - 1])
                    {
                        symmetricalH++;
                    }

                    else { return false; }
                }
            }

            // Checking if it symmetrical Horizontaly
            for (int i = 0; i < valueArray.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < Math.Ceiling((decimal)valueArray.GetLength(1) / 2); j++)
                {
                    if (valueArray[j, i] == valueArray[valueArray.GetLength(1) - j - 1, valueArray.GetLength(0) - i - 1])
                    {
                        symmetricalV++;
                    }

                    else { return false; }
                }
            }


            if (symmetricalH == Math.Ceiling((decimal)valueArray.GetLength(0) / 2) &&
                symmetricalV == Math.Ceiling((decimal)valueArray.GetLength(0) / 2))
                symetrical = true;

            return symetrical;
        }

        private static string[,] CreateTableOfAnimals(int count)
        {
            string[,] animalTable = new string[count + 1, 5];
            animalTable[0, 0] = "ID";
            animalTable[0, 1] = "Name";
            animalTable[0, 2] = "Type";
            animalTable[0, 3] = "Color";
            animalTable[0, 4] = "Behavior";

            for (int i = 1; i < animalTable.GetLength(0); i++)
            {
                for (int j = 0; j < animalTable.GetLength(1); j++)
                {
                    if (j == 0)
                        animalTable[i, 0] = $"{i}";
                    else
                    {
                        Console.WriteLine($"Please enter {animalTable[0, j]} of animal: ");
                        animalTable[i, j] = Console.ReadLine();
                    }
                }
            }

            return animalTable;
        }

        private static void DrawStars()
        {
            char[,] array = new char[4, 4];
            char star = '*';
            char space = ' ';

            // Create array of chars
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0;j < array.GetLength(1); j++)
                {
                    if((i == 0 && j == 0))
                        array[i, j] = space;
                    else if (i == 0 && j == array.GetLength(1) - 1)
                        array[i, j] = space;
                    else if (i == array.GetLength(0) - 1 && j == 0)
                        array[i, j] = space;
                    else if (i == array.GetLength(0) - 1 && j == array.GetLength(1) - 1)
                        array[i, j] = space;
                    else
                    {
                        array[i, j] = star;
                    }
                }
            }

            // Print array of chars that contains Star
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j], 2}");
                }
                Console.WriteLine();
            }
        }
    }
}