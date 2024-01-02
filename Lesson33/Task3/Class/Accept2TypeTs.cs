namespace Task3.Class
{
    internal class Accept2TypeTs<T1, T2>
    {
        private readonly T1 type1;
        private readonly T2 type2;

        public Accept2TypeTs(T1 t1, T2 t2)
        {
            type1 = t1;
            type2 = t2;
        }

        public static void GetType<T>(T? input)
        { Console.WriteLine(input?.GetType().Name); }

        public T1 GetT1() { return type1; }
        public T2 GetT2() { return type2; }
    }
}
