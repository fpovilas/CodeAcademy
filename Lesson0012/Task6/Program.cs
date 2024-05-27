using System.Text;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string sakinys;
            string apverstasSakinys;
            string bePasikartojanciuRaidziu;
            string input;
            byte choice;

            #endregion

            PrintMenu();
            Console.Write("Please type your choice: ");
            input = Console.ReadLine();
            TryGetChoice(input, out choice);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Wrong choice...");
                    break;
                case 1:
                    sakinys = GetInput();

                    apverstasSakinys = GetReversedSentece(sakinys);

                    Console.Write($"Your string in reverse: {apverstasSakinys}");
                    break;
                case 2:
                    sakinys = GetInput();

                    bePasikartojanciuRaidziu = RemoveDublicates(sakinys);

                    Console.Write("Eilute be dublikatu: " + bePasikartojanciuRaidziu);
                    break;
                default:
                    Console.WriteLine("There are only 2 tasks");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                6.1 Reverse a sentence
                6.2 Remove dublicates
                """);
        }

        private static void TryGetChoice(string v, out byte choice)
        {
            choice = 0;
            if (Byte.TryParse(v, out byte answer))
            {
                choice = answer;
            }
        }

        private static string GetInput()
        {
            Console.Write("Please input a sentence: ");
            return Console.ReadLine();
        }

        private static string GetReversedSentece(string sentence)
        {
            string[] senteceToWords = sentence.Trim().Split(" ");
            
            StringBuilder stringBuilder = new StringBuilder();

            for(int i = senteceToWords.Length - 1; i >= 0; i--)
            {
                char[] zodis = senteceToWords[i].ToCharArray();
                Array.Reverse(zodis);
                stringBuilder.Append(zodis);
                if (i - 1 >= 0)
                    stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }

        private static string RemoveDublicates(string sentence)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char[] sentenceInChars = sentence.ToCharArray().Distinct().ToArray();

            return stringBuilder.Append(sentenceInChars).ToString();
        }
    }
}