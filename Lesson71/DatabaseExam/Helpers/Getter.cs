namespace DatabaseExam.Helpers
{
    internal static class Getter
    {
        public static int ChoiceInt()
        {
            Console.Write("Your choice: ");
            if(int.TryParse(Console.ReadLine(), out int value))
                return value;
            else return -1;
        }
    }
}
