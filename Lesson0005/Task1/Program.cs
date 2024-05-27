using System.Security.Cryptography;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.1 Task\n1.2 Task\n1.3 Task");
            Console.Write("Enter you choice: ");
            byte choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter a word/sentece." +
                                    "First letter of sentece/word will be converted to uppercase");

                    string sentence = Console.ReadLine();
                    char[] sentenceInChar = sentence.ToCharArray();

                    sentenceInChar[0] = char.ToUpper(sentenceInChar[0]);

                    Console.WriteLine(new string(sentenceInChar));
                    break;
                case 2:
                    Console.WriteLine("Please enter a word/sentece." +
                                    "letters will be changed using this pattern" +
                                    "\n2 - g\n4 - b\n6 - *\n8 - x\n10 - w\n");
                    sentence = Console.ReadLine();

                    sentenceInChar = sentence.ToCharArray();

                    switch (sentenceInChar.Length)
                    {
                        case >= 10:
                            sentenceInChar[2] = 'g';
                            sentenceInChar[4] = 'b';
                            sentenceInChar[6] = '*';
                            sentenceInChar[8] = 'x';
                            sentenceInChar[10] = 'w';
                            break;
                        case 8 and < 10:
                            sentenceInChar[2] = 'g';
                            sentenceInChar[4] = 'b';
                            sentenceInChar[6] = '*';
                            sentenceInChar[8] = 'x';
                            break;
                        case 6 and < 8:
                            sentenceInChar[2] = 'g';
                            sentenceInChar[4] = 'b';
                            sentenceInChar[6] = '*';
                            break;
                        case 4 and < 6:
                            sentenceInChar[2] = 'g';
                            sentenceInChar[4] = 'b';
                            break;
                        case 2 and < 4:
                            sentenceInChar[2] = 'g';
                            break;
                        default:
                            Console.WriteLine("There is nothing to change");
                            break;
                    }
                    Console.WriteLine(sentenceInChar);
                    break;
                case 3:
                    Console.Write("Please enter 5 character word: ");
                    char[] word = Console.ReadLine().ToCharArray();

                    if (word.Length == 5)
                    {
                        Console.Write("Please enter 5 new characters to encode each character (Type without spaces):");
                        char[] encode = Console.ReadLine().ToCharArray();

                        word[0] = encode[0];
                        word[1] = encode[1];
                        word[2] = encode[2];
                        word[3] = encode[3];
                        word[4] = encode[4];
                    }
                    else { Console.WriteLine("Too much characters"); }
                    Console.WriteLine(word);
                    break;
                default:
                    Console.WriteLine("There is only 3 choices");
                    break;
            }
        }
    }
}