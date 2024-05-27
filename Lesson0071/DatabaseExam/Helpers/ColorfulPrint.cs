namespace DatabaseExam.Helpers
{
    internal static class ColorfulPrint
    {
        public static void RedWriteLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void RedWrite(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
