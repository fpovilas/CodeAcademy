using System.Runtime.InteropServices;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Printing a Welcome message
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

            // Starting first chapter of story
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\nYou were walking down the street when you suddenly ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("heard");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" a screaming from allay near by.\n" +
                "You slowly went to check what happend there,\n" +
                "but by the 5th step you felt that you");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" lost grip ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("of the ground bellow you.\n\n");
            Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("And then you realised that you are falling...\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ReadKey(true);

            Console.Write("You wake up in some kind of maze.\n" +
                "You quickly understand that to escape you will have to make ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("choices.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nYou start to hear roaring and steps " +
                "that are getting closer and closer to you!");
            Console.ReadKey(true);

            // Giving a first choice
            Console.Write("\n\nYour fist choice. Do you stay or run? ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string choice = Console.ReadLine();
            if (choice != null && choice.ToLower() == "stay")
            {
                // Death
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou are dead bud!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            // Correct choice
            else if (choice != null && choice.ToLower() == "run")
            {
                //Start of second chapter
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nBy running for couple of seconds which seemed as couple hours" +
                    "\nYou manage to reache end of the tunnel where it splits in 3 seperate tunnels." +
                    "\nOn every tunnel entrence you see number:");
                Console.Write("\n1st tunnel has number ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("1");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n2nd tunnel has number ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("54");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n3rd tunnel has number ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("117");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\nNear the entrance of tunnels on the wall you see a riddle:\n" +
                    "One is three - Two is one - Three is zero.");
                Console.Write("\nYour choice 1, 2 or 3: ");

                // Second choice
                Console.ForegroundColor = ConsoleColor.DarkRed;
                choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                if(choice != null && (choice.ToLower() == "2" || choice.ToLower() == "54"))
                {
                    // Correct Choice. Third chapter.
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\nYou go into the tunnel and find a door with a lock near");
                    Console.WriteLine("On the door you find scratches that looks like some ones writing");
                    Console.WriteLine("You lean over to take a better look and you see\n");
                    Console.Write("First is last - Last is middle - Middle is first");
                    Console.WriteLine("\nOn the wall near by you see date 11-2023-07");

                    // Third choice
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nYour answer? (Write only numbers): ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    choice = Console.ReadLine();

                    Console.ForegroundColor= ConsoleColor.Green;
                    if(choice != null && choice == "20230711")
                    {
                        // Correct choice. End of game
                        Console.WriteLine("\nYou enter the code and the lock clicks.\n" +
                            "Door opens and you see exit to outside.\n" +
                            "You climb outside and run to your home...");
                        Console.WriteLine("\nYou survived.\n\n The End!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        //Wrong choice. Death
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You entered wrong code. Monster reaches you" +
                            ". And slays you!");
                        Console.WriteLine("You are dead!");
                        Console.WriteLine("\n\n The End!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else
                {
                    //Wrong choice. Death
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered the tunnel and reached dead end");
                    Console.WriteLine("You are dead!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                //Wrong choice. Death
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong choice buddy");
                Console.WriteLine("You are dead!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}