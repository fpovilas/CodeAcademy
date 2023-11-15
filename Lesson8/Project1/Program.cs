namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* *********************************** /*
             * Rules for Rock, Paper, Scissors      *
             * ************************************ *
             * Rock < Paper                         *
             * Rock > Scissors                      *
             * Rock = Rock                          *
             * ************************************ *
             * Paper < Scissors                     *
             * Paper > Rock                         *
             * Paper = Paper                        *
             * ************************************ *
             * Scissors < Rock                      *
             * Scissors > Paper                     *
             * Scissors = Scissors                  *
             * ************************************ */

            #region Variables
            string? playerName = null;
            string? playerChoice = null;
            string? oponentChoice = null;
            string? playerChoiceToLower = null;
            string? oponnentChoiceToLower = null;
            char[] playerChoiceCharArray;
            char[] oponentChoiceCharArray;
            int playerScore = 0;
            int oponentScore = 0;
            int randomNumber, oponentNumber;
            bool isDone = false;
            Random random;
            #endregion

            Console.WriteLine("Paper, scissors, rock");
            Console.WriteLine("You play best of 3");
            Console.WriteLine("You have to win 2 times to win this game");
            Console.Write("Please enter your name: ");
            playerName = Console.ReadLine();

            random = new Random();

            do
            {
                randomNumber = random.Next(1, 34);
                oponentNumber = randomNumber % 3;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Openent: {oponentScore} x {playerName} {playerScore}\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Rock, Paper or Scissors? ");
                playerChoiceToLower = Console.ReadLine().ToLowerInvariant();
                playerChoiceCharArray = playerChoiceToLower.ToCharArray();
                playerChoiceCharArray[0] = Char.ToUpper(playerChoiceCharArray[0]);
                playerChoice = new string(playerChoiceCharArray);

                switch (oponentNumber)
                {
                    case 0:
                        oponnentChoiceToLower = "rock";
                        break;
                    case 1:
                        oponnentChoiceToLower = "scissors";
                        break;
                    case 2:
                        oponnentChoiceToLower = "paper";
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

                oponentChoiceCharArray = oponnentChoiceToLower.ToCharArray();
                oponentChoiceCharArray[0] = Char.ToUpper(oponnentChoiceToLower[0]);
                oponentChoice = new string(oponentChoiceCharArray);

                if (playerChoiceToLower == "rock" && oponnentChoiceToLower == "scissors")
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");
                    playerScore += 1;

                    if(playerScore == 2 || oponentScore == 2) isDone = true;

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }
                else if (playerChoiceToLower == "rock" && oponnentChoiceToLower == "paper")
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");
                    oponentScore += 1;

                    if (playerScore == 2 || oponentScore == 2) isDone = true;

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }
                else if (playerChoiceToLower == "paper" && oponnentChoiceToLower == "rock")
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");
                    playerScore += 1;

                    if (playerScore == 2 || oponentScore == 2) isDone = true;

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }
                else if (playerChoiceToLower == "paper" && oponnentChoiceToLower == "scissors")
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");
                    oponentScore += 1;

                    if (playerScore == 2 || oponentScore == 2) isDone = true;

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }
                else if (playerChoiceToLower == "scissors" && oponnentChoiceToLower == "paper")
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");
                    playerScore += 1;

                    if (playerScore == 2 || oponentScore == 2) isDone = true;

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }
                else if (playerChoiceToLower == "scissors" && oponnentChoiceToLower == "rock")
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");
                    oponentScore += 1;

                    if (playerScore == 2 || oponentScore == 2) isDone = true;

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine($"\nOpenent: {oponentChoice} x {playerName} {playerChoice}");

                    Console.WriteLine("To continue press any key.");
                    Console.ReadKey(true);
                }

            } while (!isDone);

            if(playerScore == 2)
                Console.WriteLine($"{playerName} wins. Openent: {oponentScore} x {playerName} {playerScore}");
            else
                Console.WriteLine($"Oponent wins. Openent: {oponentScore} x {playerName} {playerScore}");
        }
    }
}