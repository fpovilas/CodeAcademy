using System.Dynamic;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            byte choice;
            double sum = 0, num;
            string number, correctPass = "Password", pass, answer;
            Random random;
            int randomNumber, guessedNumber;

            #endregion

            Console.WriteLine("""
                5.1 Number addition
                5.2 Login screen
                5.3 Number guessing from 0 to 100
                """);
            Console.Write("Your choice: ");
            choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    do
                    {
                        Console.Write("Please enter the number(To stop adding numbers please type \"Finish\"): ");
                        number = Console.ReadLine();
                        if(double.TryParse(number, out num))
                            sum += num;
                    } while (number.ToLower() != "finish");

                    Console.WriteLine($"The sum is {sum}");
                    break;
                case 2:
                    do
                    {
                        Console.Write("Please enter your password: ");
                        pass = Console.ReadLine();

                        if(pass != correctPass)
                            Console.WriteLine("Password is incorrect. Please try again!");
                    } while (pass != "Password");

                    Console.WriteLine("You have successfully logged in");
                    break;
                case 3:
                    random = new Random();
                    randomNumber = random.Next(0, 100);

                    do
                    {
                        Console.Write("Please guess number between 0 and 100: ");
                        guessedNumber = Convert.ToInt32(Console.ReadLine());

                        if (guessedNumber > randomNumber) Console.WriteLine("You number is bigger then generated one!");
                        else if (guessedNumber < randomNumber) Console.WriteLine("You number is smaller then generated one!");
                        else Console.WriteLine("You guessed the number!");
                    } while (randomNumber != guessedNumber);
                    break;
                default:
                    Console.WriteLine("There is only 3 tasks");
                    break;
            }
        }
    }
}