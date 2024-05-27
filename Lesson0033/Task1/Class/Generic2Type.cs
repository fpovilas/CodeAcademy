namespace Task1.Class
{
    internal class Generic2Type<T1, T2>
    {
        private T1? t1;
        private T2? t2;

        public T1? GetT1() => t1;
        public T2? GetT2() => t2;

        public T1? SetT1(T1 value) => t1 = value;
        public T2? SetT2(T2 value) => t2 = value;

        public void Print()
        {
            Console.WriteLine($"T1 is {t1?.GetType().Name} : {t1}\n" +
                            $"T2 is {t2?.GetType().Name} : {t2}");
        }
    }
}
