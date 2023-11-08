namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("3.1 Task\n3.2 Task\n3.3 Task");
            Console.Write("Enter you choice: ");
            byte choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Please enter a word: ");
                    string word = Console.ReadLine();

                    if(word.Substring(0, 1) != word.Substring(0,1).ToUpper())
                    {
                        char[] wordToCharArray = word.ToCharArray();
                        wordToCharArray[0] = char.ToUpper(wordToCharArray[0]);

                        Console.Write(wordToCharArray);
                    }
                    else { Console.Write(word); }
                    break;
                case 2:
                    Console.Write("Please enter a word: ");
                    word = Console.ReadLine();

                    if (word.Contains('a'))
                    {
                        Console.Write($"{word} {word.IndexOf('a')}");
                    }
                    else { Console.Write("Character 'a' not found"); }
                    break;
                case 3:
                    Console.Write("Please enter a word: ");
                    word = Console.ReadLine();

                    if (word == "hello")
                    {
                        char[] wordToChar = word.ToCharArray();
                        Array.Reverse(wordToChar);
                        Console.Write($"{new string(wordToChar)}");
                    }
                    else { Console.Write(word); }
                    break;
                default:
                    Console.WriteLine("There is only 3 choices");
                    break;
            }
        }
    }
}