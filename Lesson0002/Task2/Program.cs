namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "My name is Povilas";
            string name = sentence.Substring(sentence.IndexOf('P'));
            string my = sentence.Substring(0, 2);

            Console.WriteLine(sentence);
            Console.WriteLine(name);
            Console.WriteLine(my);
        }
    }
}