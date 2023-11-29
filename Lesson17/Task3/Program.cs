﻿using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            x = GenerateRandomNumber(1, 8);
            y = GenerateRandomNumber(1, 8);

            #region 1st part
            /*
            int[,] matrix = FillMatrixWithNumbers(x, y, 1, 80);

            int evenNumCount = CalculateEvenAndOddNumbersInArray(matrix, out int oddNumCount);

            PrintMatrix(matrix);

            double evenPercent = (double)evenNumCount / (matrix.GetLength(0) * matrix.GetLength(1)) * 100;
            double oddPercent = 100 - evenPercent;

            Console.WriteLine($"In this array even numbers is {evenPercent:#.##}% and odd {oddPercent:#.##}%");
            */
            #endregion

            #region 2nd part
            /*
            int[,] exMatrix = FillMatrixWithNumbers(x, y);

            PrintMatrix(exMatrix);
            */
            #endregion

            int[,] exExMatrix = FillMatrixWithDistinctNumbers(x, y);

            PrintMatrix(exExMatrix);
        }

        private static int GenerateRandomNumber(int minNum, int maxNum)
        {
            var random = new Random();
            return random.Next(minNum, maxNum + 1);
        }

        // Generation for 1st part
        private static int[,] FillMatrixWithNumbers(int x, int y, int minNum, int maxNum)
        {
            int[,] mat = new int[x, y];

            for(int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    mat[i, j] = GenerateRandomNumber(minNum, maxNum);
                }
            }

            return mat;
        }

        // Generation for 2nd part (Extension)
        private static int[,] FillMatrixWithNumbers(int x, int y)
        {
            int[,] mat = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    mat[i, j] = GenerateRandomNumber(1, 9) + i * 10;
                }
            }

            return mat;
        }

        // Generation for 2nd part (Extension)
        private static int[,] FillMatrixWithDistinctNumbers(int x, int y)
        {
            int[,] mat = new int[x, y];
            List<int> mat1D = new List<int> {};

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int num;

                    do
                    { num = GenerateRandomNumber(1, 9) + i * 10; }
                    while (DoArrayContainsThisNum(mat1D, num));

                    mat[i, j] = num;
                }
            }

            return mat;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for(int i = 0; i<matrix.GetLength(0); i++)
            {
                for(int j = 0; j<matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int CalculateEvenAndOddNumbersInArray(int[,] matrix, out int oddNumCount)
        {
            oddNumCount = 0;
            int evenNumCount = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 != 0)
                    { oddNumCount++; }
                    else { evenNumCount++; }
                }
            }

            return evenNumCount;
        }

        private static bool DoArrayContainsThisNum(List<int> mat1D, int num)
        {
            foreach(int i in mat1D)
            {
                if(i == num)
                    return true;
            }

            return false;
        }
    }
}