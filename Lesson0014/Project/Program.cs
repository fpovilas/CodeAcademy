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
            int[] coords;
            int whichPlayerTurn;

            #endregion

            playerNames = new string[2];
            gameBoard = new string[3,3];
            whichPlayerTurn = 1;

            PopulatePlayerNames(ref playerNames);

            while (true)
            {
                PrintBoard(gameBoard);

                switch (whichPlayerTurn)
                {
                    case 1:
                        coords = GetYX();

                        gameBoard[coords[0], coords[1]] = "x";

                        whichPlayerTurn = 2;
                        break;
                    case 2:
                        coords = GetYX();

                        gameBoard[coords[0], coords[1]] = "o";

                        whichPlayerTurn = 1;
                        break;
                    default:
                        break;
                }
            }
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
            Console.Clear();

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

        private static int[] GetYX()
        {
            int[] coord = new int[2];
            Console.Write("Please enter X coordinate: ");
            if(!int.TryParse(Console.ReadLine(), out coord[0]))
            { coord[0] = 0; }

            Console.Write("Please enter Y coordinate: ");
            if (!int.TryParse(Console.ReadLine(), out coord[1]))
            { coord[1] = 0; }

            return coord;
        }
    }
}