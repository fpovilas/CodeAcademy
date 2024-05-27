

namespace DatabaseExam.Helpers
{
    internal static class Getter
    {
        internal static int ChoiceInt()
        {
            Console.Write("Your choice: ");
            if(int.TryParse(Console.ReadLine(), out int value))
                return value;
            else return -1;
        }

        internal static bool GetBoolValue(string text)
        {
            
            do
            {
                string choice = GetString(text)!;
                switch (choice.ToLower())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        break;
                }
            }while(true);
        }

        internal static string GetString(string text)
        {
            bool stopLoop = false;
            string? value;
            do
            {
                Console.Clear();
                Console.Write(text);
                value = Console.ReadLine();
                if(!string.IsNullOrEmpty(value))
                {
                    if(!string.IsNullOrWhiteSpace(value))
                        stopLoop = true;
                }
            } while (!stopLoop);

            return value!;
        }

        internal static int GetInt(string text)
        {
            int value;
            do
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out int num))
                { value = num; }
                else value = -1;
            } while (value == -1);

            return value;
        }
    }
}
