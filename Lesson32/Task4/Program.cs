namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            MyList<string> list = new();
            list.AddElement("Labas");
            list.AddElement("Ate");
            list.AddElement("Labas");
            list.RemoveElement("Labas");
        }
    }
}
// Extend the MySelfCreatedList sample class with a method to delete an item from an array.