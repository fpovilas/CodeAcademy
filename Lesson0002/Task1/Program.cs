namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Some text!";

            Console.WriteLine(
                $"{text}\n" +
                $"5th char is {text[5]}\n" +
                $"Length of string is {text.Length}");
        }
    }
}