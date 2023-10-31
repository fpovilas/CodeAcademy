namespace Taks3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToTest = "    This is a string to test string class methods";

            string tryingSubstring = stringToTest.Substring(4,8);
            string tryingReplace = stringToTest.Replace('i', 'I');
            int tryingIndexOf = stringToTest.IndexOf("class");
            string tryingTrim = stringToTest.Trim();
            string tryingToLowerInvariant = stringToTest.ToLowerInvariant();
            string tryingToUpperInvariant = stringToTest.ToUpperInvariant();

            Console.WriteLine(
                $"{stringToTest}\n" +
                $"{tryingSubstring}\n" +
                $"{tryingReplace}\n" +
                $"{tryingIndexOf}\n" +
                $"{tryingTrim}\n" +
                $"{tryingToLowerInvariant}\n" +
                $"{tryingToUpperInvariant}"
                );
        }
    }
}