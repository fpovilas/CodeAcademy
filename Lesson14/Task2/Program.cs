using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string choice;
            int x, y;
            int[,] arr;
            int[,] arrSubTask2;
            int[] repeatedNums;
            string[,] repeatedNames;
            string[] repeatedNms;
            int[,] arrayA;
            int[,] arrayB;
            int[,] arrayC;

            #endregion

            PrintMenu();

            choice = GetChoice();

            switch (choice)
            {
                case "2.1":
                    Console.Write("Please enter X: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter y: ");
                    y = Convert.ToInt32(Console.ReadLine());

                    arr = GetValueFromMultiArray(x, y);

                    PrintMultidimensionalArray(arr);
                    break;
                case "2.2":
                    arrSubTask2 = new int[,] { { 1, 2 }, { 2, 5 }, { 3, 5 } };

                    repeatedNums = GetRepeatedNumbersIn2DArr(arrSubTask2);

                    foreach(int num in repeatedNums)
                    {  Console.Write($"{num} "); }

                    break;
                case "2.3":
                    repeatedNames = new string[,] { { "Povilas", "Fri" }, { "Povilas", "Pet" }, { "Stasys", "Pet" } };

                    repeatedNms = GetRepeatedNamesIn2DArr(repeatedNames);

                    foreach(string name in repeatedNms)
                    { Console.Write($"{name} "); }

                    break;
                case "2.4":
                    arrayA = new int[,]{
                        {1, 2, 3},
                        {2, 2, 2},
                        {5, 7, 9}
                    };

                    arrayB = new int[,]
                    {
                        {1},
                        {2},
                        {3}
                    };

                    arrayC = Multiply2DArrays(arrayA, arrayB);

                    PrintMultidimensionalArray(arrayC);

                    break;
                default:
                    Console.WriteLine("There is only 4 tasks or wrong choice");
                    break;
            }

            
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                2.1 Create multidimensional array
                2.2 Find dublicate numbers in 2D array
                2.3 Find dublicate strings in 2D array
                2.4 Multiply 2D Arrray
                """);
        }

        private static string GetChoice()
        {
            Console.Write("Please eneter your choice: ");
            return Console.ReadLine();
        }

        private static int[,] GetValueFromMultiArray(int x, int y)
        {
            int[,] arr = new int[x, y];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Please enter {i + 1} row {j + 1} column number: ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            return arr;
        }

        private static void PrintMultidimensionalArray(int[,] arr )
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        private static int[] GetRepeatedNumbersIn2DArr(int[,] arrSubTask2)
        {
            int[] arr = Get1DINTArray(arrSubTask2);
            int[] newArr = new int[arr.Length / 2];
            int counter = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i; j < arr.Length; j++)
                {
                    if (j + 1 < arr.Length)
                    {
                        if (arr[i] == arr[j + 1])
                        {
                            newArr[counter] = arr[i];
                            counter++;
                            break;
                        }
                    }
                }
            }

            return TrimIntArray(newArr, counter);
        }

        private static int[] TrimIntArray(int[] newArr, int counter)
        {
            int[] trimedArray = new int[counter];

            for(int i = 0; i < trimedArray.Length;i++)
            {
                trimedArray[i] = newArr[i];
            }

            return trimedArray;
        }

        private static int[] Get1DINTArray(int[,] arr)
        {
            int counter = 0;
            int[] newArr = new int[arr.GetLength(0) * arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    newArr[counter] = arr[i, j];
                    counter++;
                }
            }

            return newArr;
        }

        private static string[] GetRepeatedNamesIn2DArr(string[,] repeatedNames)
        {
            string[] array1D = Get1DStringArray(repeatedNames);
            string[] newArr = new string[array1D.Length / 2];
            int counter = 0;

            for (int i = 0; i < array1D.Length; i++)
            {
                for (int j = i; j < array1D.Length; j++)
                {
                    if (j + 1 < array1D.Length)
                    {
                        if (array1D[i] == array1D[j + 1])
                        {
                            newArr[counter] = array1D[i];
                            counter++;
                            break;
                        }
                    }
                }
            }

            return TrimStringArray(newArr, counter);
        }

        private static string[] TrimStringArray(string[] newArr, int counter)
        {
            string[] trimedArray = new string[counter];

            for (int i = 0; i < trimedArray.Length; i++)
            {
                trimedArray[i] = newArr[i];
            }

            return trimedArray;
        }

        private static string[] Get1DStringArray(string[,] repeatedNames)
        {
            string[] array = new string[repeatedNames.GetLength(0) * repeatedNames.GetLength(1)];
            int counter = 0;

            for(int i = 0; i < repeatedNames.GetLength(0); i++ )
            {
                for(int j = 0; j < repeatedNames.GetLength(1); j++)
                {
                    array[counter++] = repeatedNames[i, j];
                }
            }

            return array;
        }

        private static int[,] Multiply2DArrays(int[,] arrayA, int[,] arrayB)
        {
            int[,] arrayC = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
            int val = 0;

            for(int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    val += (arrayA[i, j] * arrayB[j, arrayB.GetLength(1) - 1]);
                }
                arrayC[i, arrayB.GetLength(1) - 1] = val;
                val = 0;
            }

            return arrayC;
        }
    }
}