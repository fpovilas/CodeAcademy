namespace Task1.Class
{
    internal abstract class GenerateRandom
    {
        public static int GetRandomNum()
        {
            Random rnd = new();
            return rnd.Next(0, 11);
        }
    }
}
