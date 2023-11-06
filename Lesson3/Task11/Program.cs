using System.Runtime.InteropServices;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("MaZe MaSSaCeR tHe GamE\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("""
                        @@@@@@@@@@@@@@@@@@
                     @@@@@@@@@@@@@@@@@@@@@@@
                   @@@@@@@@@@@@@@@@@@@@@@@@@@@
                  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                 @@@@@@@@@@@@@@@/      \@@@/   @
                @@@@@@@@@@@@@@@@\      @@  @___@
                @@@@@@@@@@@@@ @@@@@@@@@@  | \@@@@@
                @@@@@@@@@@@@@ @@@@@@@@@\__@_/@@@@@
                 @@@@@@@@@@@@@@@/,/,/./'/_|.\'\,\
                   @@@@@@@@@@@@@|  | | | | | | | |
                                 \_|_|_|_|_|_|_|_|
                """);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nIf you ready to play press any key...");
            Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\nYou were walking down the street when you suddenly ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("heard");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" a screaming from allay near by. You slowly went to check" +
                " what happend there, but by the 5th step you felt that you");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" lost grip ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("of the ground bellow you.\n\n");
            Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("And then you realised that you are falling...\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ReadKey(true);

            Console.Write("You wake up in some kind of maze. You fastly understand " +
                "that to escape you have to make ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("choices");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(". Because you start to hear roaring and steps " +
                "that are getting closer and closer");
            Console.ReadKey(true);

            Console.Write("\n\nYour fist choice. Do you stay or run? ");
            string choice = Console.ReadLine();
            if (choice != null && choice.ToLower() == "stay")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou are dead bud!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (choice != null && choice.ToLower() == "run")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nBy running for couple of seconds which seemed as couple hours" +
                    "\nYou manage to reache end of the tunnel where it splits in 3 seperate tunnels. On every tunnel entrence you see number:" +
                    "\n\n1st tunnel has number 1" +
                    "\n2nd tunnel has number 54" +
                    "\n3rd tunnel has number 117" +
                    "\n\nNear the entrance you see a word:\n" +
                    "One is three - Two is one - Three is zero.");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                choice = Console.ReadLine();
                if(choice != null && choice.ToLower() == "2")
                { Console.WriteLine("You live for the next day"); }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry bud. Wrong Choice");
                    Console.WriteLine("You are dead!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong choice buddy");
                Console.WriteLine("You are dead!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}