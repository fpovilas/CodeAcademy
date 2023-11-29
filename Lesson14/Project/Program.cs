using System.Runtime.CompilerServices;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string[] playerNames;
            string[,] gameBoard;

            #endregion

            playerNames = new string[2];
            gameBoard = new string[3,3];

            PopulatePlayerNames(ref playerNames);

            PrintBoard(gameBoard);
        }

        private static void PopulatePlayerNames(ref string[] playerNames)
        {
            for (int i = 0; i < playerNames.Length; i++)
            {
                Console.Write($"Please enter player {i + 1} name: ");
                playerNames[i] = Console.ReadLine();
            }
        }

        private static void PrintBoard(string[,] gameBoard)
        {
            Console.Write($"{'|',3}{0,3}|{1,3}|{2,3}|\n");
            Console.Write($"---------------\n");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.Write($"{i, 2}|");
                for (int j = 0;  j < gameBoard.GetLength(1); j++)
                {
                    Console.Write($"{gameBoard[i,j], 3}|");
                }
                Console.WriteLine();
            }
        }
    }
}