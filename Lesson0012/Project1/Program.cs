using System.Security.Cryptography;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string choice;
            string[] riddles;

            #endregion

            PrintWelcome();
            PrintChapterI();
            choice = GetFirstChoice();

            switch (choice.ToLower())
            {
                case "run":
                    PrintChapterII();
                    choice = GetSecondChoice();

                    switch (choice)
                    {
                        case "2":
                        case "54":
                            PrintChapterIII();

                            choice = GetThirdChoice();

                            switch (choice)
                            {
                                case "20230711":
                                    riddles = PrintFinalChapter();

                                    choice = GetFinalChoice().ToLower();

                                    switch (choice)
                                    {
                                        case "rgb":
                                            PrintEnding(riddles);
                                            break;
                                        default:
                                            PrintFinalChapterDeath();
                                            break;
                                    }

                                    break;
                                default:
                                    PrintChapterIIIDeath();
                                    break;
                            }

                            break;
                        default:
                            PrintChapterIIDeath();
                            break;
                    }
                    break;
                case "stay":
                    PrintChapterIDeath();
                    break;
                default:
                    PrintGenericDeath();
                    break;
            }
        }

        #region Functions

        private static void PrintWelcome()
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
        }

        private static void PrintChapterI()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\nYou were walking down the street when you suddenly ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("heard");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" a screaming from alley near by.\n" +
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
        }

        private static string GetFirstChoice()
        {
            Console.Write("\n\nYour first choice. Do you stay or run? ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return Console.ReadLine();
        }

        private static void PrintChapterII()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nBy running for couple of seconds which seemed as couple hours." +
                "\nYou manage to reach end of the tunnel where it splits in 3 seperate tunnels." +
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
            Console.Write("\nWhich tunnel you choose 1st, 2nd or 3rd?: ");
        }

        private static string GetSecondChoice()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return Console.ReadLine();
        }

        private static void PrintChapterIIDeath()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You entered the tunnel and reached dead end");
            Console.WriteLine("You are dead!");
            Console.ResetColor();
        }

        private static void PrintChapterIII()
        {
            // Correct Choice. Third chapter.
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nYou go into the tunnel and find a door with a lock.");
            Console.WriteLine("On the door you find scratches that looks like someones writing.");
            Console.WriteLine("You lean over to take a better look and you see\n");
            String dateRiddle = "First is last - Last is middle - Middle is first";

            // String manipulation.  Lesson 5 Upgrade
            dateRiddle = dateRiddle.Replace('i', 'I').Replace('s', 'S').Replace('t', 'T');
            Console.Write(dateRiddle);
            Console.WriteLine("\n\nOn the wall near by you see date 11-2023-07");
        }

        private static string GetThirdChoice()
        {
            // Third choice
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nYour answer? (Write only numbers): ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return Console.ReadLine();
        }

        private static void PrintChapterIIIDeath()
        {
            //Wrong choice. Death
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You entered wrong code. Monster reaches you" +
                ". And slays you!");
            Console.WriteLine("You are dead!");
            Console.WriteLine("\n\n The End!");
            Console.ResetColor();
        }

        private static string[] PrintFinalChapter()
        {
            // Correct choice.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou enter the code and the lock clicks.\n" +
                "Door opens and you were hoping to see exit...\n" +
                "But... It's just another dark tunnel ahead...\n" +
                "You walk through that tunnel and after couple of steps you start to see" +
                " a dim ray of light crossing your path.\n" +
                "You start sprinting to the light and while sprinting you find a parchment paper lying on the ground.\n" +
                "You pick it up and start reading\n\n");

            #region Lorem ipsum
            //Lorem ipsum with marked letters (RGB)
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Lorem ipsum dolor si");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("t");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" amet, consec");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("t");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("t");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("ur adipiscing eli");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("t");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(".\n");
            Console.Write("Mauris sit amet metus nec turpis faucibus eleifend.\n");
            Console.Write("Nam mollis in nulla in laoreet.\n");
            Console.Write("Aenean s");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("dales ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("rnare magna, nec tristique turpis pulvinar ut.\n");
            Console.Write("Donec viverra metus in risus dictum feugiat.\n");
            Console.Write("Morbi feugiat turpis nec feugiat iaculis.\n");
            Console.Write("V");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("stibulum ut v");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("natis nisi. Morbi imp");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("rdi");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("t.\n\n\n");
            #endregion

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("While reading the text in parchment\n" +
                "you reach other wooden door with lock. " +
                "But it's not ordinary door. It opens only if you solve the riddle\n\n");

            string riddlePieceOne = "The great do";
            string riddlePieceTwo = "or of big gods, o";
            string riddlePieceThree = "h please open up";

            // String manipulation.  Lesson 5 Upgrade
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{riddlePieceOne.Replace("t", "r")}" +
                            $"{riddlePieceTwo.Replace("o", "g")}" +
                            $"{riddlePieceThree.Replace("e", "b")}\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            return new string[] { riddlePieceOne, riddlePieceTwo, riddlePieceThree};
        }

        private static string GetFinalChoice()
        {
            Console.Write("To solve a riddle you have to write a answer without spaces: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine().ToLower();
        }

        private static void PrintFinalChapterDeath()
        {
            //Wrong choice. Death
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You entered wrong code. Monster reaches you" +
                ". And slays you!");
            Console.WriteLine("You are dead!");
            Console.WriteLine("\n\n The End!");
            Console.ResetColor();
        }

        private static void PrintEnding(string[] riddles)
        {
            string riddlePieceOne = riddles[0], riddlePieceTwo = riddles[1], riddlePieceThree = riddles[2];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou silently say {riddlePieceOne}{riddlePieceTwo}{riddlePieceThree}\n" +
                $"In you mind you shout to your self... \"Yes this is it. That the answer\"." +
                $"And you reapeat it couple times.\n" +
                $"{riddlePieceOne}{riddlePieceTwo}{riddlePieceThree}\n" +
                $"{riddlePieceOne}{riddlePieceTwo}{riddlePieceThree}\n" +
                $"Every time more lounder and louder." +
                $"Then the door cracles and it slowly opens up.");
            Console.WriteLine("\nYou escaped.\n\n The End!");
            Console.ResetColor();
        }

        private static void PrintGenericDeath()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong choice buddy");
            Console.WriteLine("You are dead!");
            Console.ResetColor();
        }

        private static void PrintChapterIDeath()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou are dead bud!");
            Console.ResetColor();
        }

        #endregion

    }
}