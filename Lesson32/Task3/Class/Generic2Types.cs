namespace Task3.Class
{
    internal class Generic2Types<T1, T2>
    {
        private T1 TypeOne { get; set; }
        private T2 TypeTwo { get; set; }

        public Generic2Types(T1 typeOne, T2 typeTwo)
        {
            TypeOne = typeOne;
            TypeTwo = typeTwo;
        }

        public override string ToString()
        {
            return $"TypeOne is {TypeOne?.GetType().Name} value: {TypeOne}\n"
                   + $"TypeTwo is {TypeTwo?.GetType().Name} value: {TypeTwo}";
        }
    }
}
