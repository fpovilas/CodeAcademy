namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string? word, sentece;
            char[] charArray;
            char firstSentenceLetter, lastSentenceLetter;

            #endregion

            PrintMenu();
            GetChoice(out string? choice);

            switch (choice)
            {
                case "1":
                case "2.1":
                    Console.Write("Please enter a string: ");
                    word = Console.ReadLine();

                    charArray = ConvertStringToCharArraty(word);

                    for (int i = 0; i < charArray.Length; i++)
                    {
                        Console.Write(charArray[i]);
                        if(i < charArray.Length - 1)
                            Console.Write(" ");

                    }
                    break;
                case "2":
                case "2.2":
                    Console.Write("Please enter a sentence: ");
                    sentece = Console.ReadLine();

                    firstSentenceLetter = ReturnFirstSentenceLetter(sentece);

                    Console.WriteLine($"First sentence letter is {firstSentenceLetter}");
                    break;
                case "3":
                case "2.3":
                    Console.Write("Please enter a sentence: ");
                    sentece = Console.ReadLine();

                    lastSentenceLetter = ReturnLastSentenceLetter(sentece);

                    Console.WriteLine($"Last sentence letter is {lastSentenceLetter}");
                    break;
                default:
                    Console.WriteLine("There is only 3 tasks!");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                2.1 Convert string to char array and the print it
                2.2 Return first sentece letter
                2.3 Return last sentece letter
                """);
        }

        private static void GetChoice(out string? choice)
        {
            Console.Write("Please enter your choice: ");
            choice = Console.ReadLine();
        }

        private static char[] ConvertStringToCharArraty(string? str)
        {
            if (str != "" || str != null)
            {
                return str.ToCharArray();
            }
            else
                return Array.Empty<char>();
        }

        private static char ReturnFirstSentenceLetter(string? sentece)
        {
            char[] sentenceArr = sentece.ToCharArray();
            return sentenceArr[0];
        }

        private static char ReturnLastSentenceLetter(string? sentece)
        {
            char[] sentenceArr = sentece.ToCharArray();
            return sentenceArr.Last();
        }
    }
}