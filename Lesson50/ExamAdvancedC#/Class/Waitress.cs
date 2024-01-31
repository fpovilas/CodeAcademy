namespace ExamAdvancedCSharp.Class
{
    internal class Waitress(string name)
    {
        private string Name { get; set; } = name;
        private Customer? Customer { get; set; }
    }
}
