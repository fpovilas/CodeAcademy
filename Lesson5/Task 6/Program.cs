namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            // Constants
            const string sentenceToCheckAgainst = "true love";

            // Basic vars
            string firstPersonName, secondPersonName, combinedScore, compatibility;
            char[] firstPersonNameInChar, secondPersonNameInChar;
            int firstPersonLetterSum = 0, secondPersonLetterSum = 0;
            #endregion

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("True Love System <3");
            Console.ForegroundColor= ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*** Name can contain up to 10 characters ***\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("\nPlease write your name: ");
            firstPersonName = Console.ReadLine();
            Console.Write("Please write name of other person: ");
            secondPersonName = Console.ReadLine();

            // Conversion to char
            firstPersonNameInChar = firstPersonName.ToCharArray();
            secondPersonNameInChar = secondPersonName.ToCharArray();

            // Checking how long are names and deciding if me have to continue

            if(firstPersonNameInChar.Length <= 10 && secondPersonNameInChar.Length <= 10)
            {
                // Counting firstPersonLetterSum
                switch (firstPersonNameInChar.Length)
                {
                    case 10:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[4]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[5]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[6]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[7]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[8]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[9]);
                        break;
                    case 9:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[4]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[5]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[6]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[7]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[8]);
                        break;
                    case 8:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[4]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[5]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[6]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[7]);
                        break;
                    case 7:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[4]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[5]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[6]);
                        break;
                    case 6:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[4]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[5]);
                        break;
                    case 5:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[4]);
                        break;
                    case 4:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[3]);
                        break;
                    case 3:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[2]);
                        break;
                    case 2:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[1]);
                        break;
                    case 1:
                        firstPersonLetterSum += sentenceToCheckAgainst.Count(x => x == firstPersonNameInChar[0]);
                        break;
                    default:
                        Console.WriteLine("Name have to have letters in it");
                        break;
                }

                // Counting secondPersonLetterSum
                switch (secondPersonNameInChar.Length)
                {
                    case 10:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[4]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[5]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[6]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[7]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[8]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[9]);
                        break;
                    case 9:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[4]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[5]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[6]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[7]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[8]);
                        break;
                    case 8:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[4]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[5]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[6]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[7]);
                        break;
                    case 7:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[4]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[5]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[6]);
                        break;
                    case 6:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[4]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[5]);
                        break;
                    case 5:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[4]);
                        break;
                    case 4:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[3]);
                        break;
                    case 3:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[2]);
                        break;
                    case 2:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[1]);
                        break;
                    case 1:
                        secondPersonLetterSum += sentenceToCheckAgainst.Count(x => x == secondPersonNameInChar[0]);
                        break;
                    default:
                        Console.WriteLine("Name have to have letters in it");
                        break;
                }

                // Creating total score
                combinedScore = firstPersonLetterSum.ToString() + secondPersonLetterSum.ToString();

                Console.WriteLine($"{firstPersonName} + {secondPersonName} is {combinedScore}");

                int combinedScoreToInt = Convert.ToInt32(combinedScore);
                compatibility = combinedScoreToInt switch
                {
                    > 90 or < 30 => "You are perfect for each other",
                    >= 50 and <= 70 => "You are right for each other",
                    _ => "The system cannot tell if you are right for each other"
                };
                Console.WriteLine(compatibility);
            }
            else { Console.WriteLine("One or Both names are longer the 10 characters"); }


            // Need to use Count and Length
        }
    }
}