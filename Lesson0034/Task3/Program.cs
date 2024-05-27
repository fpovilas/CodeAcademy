namespace Task3
{
    public class Program
    {
        static void Main() {}

        public static bool CheckIfNull<T>(T obj)
        {
            if(obj == null)
            {
                return true;
            }
            return false;
        }
    }
}
