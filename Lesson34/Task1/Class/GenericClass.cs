namespace Task1.Class
{
    internal class GenericClass<T>(List<T> genList)
    {
        private readonly List<T> genericList = genList;

        public void Print()
        {
            foreach (var gen in genericList)
            {
                Console.WriteLine(gen);
            }
        }

        public T[] ReturnArray() => genericList.ToArray();

        public T FindExactMatch(T valueToFind)
        {
            int counter = 0;

            foreach (T gen in genericList)
            {
                if(gen!.Equals(valueToFind))
                    counter++;
            }

            return counter switch
            {
                0 => throw new Exception("There is no match"),
                > 1 => throw new Exception("There is more than one match"),
                _ => valueToFind,
            };
        }

        public T FindExactMatchWithDefault(T valueToFind)
        {
            int counter = 0;

            foreach (T gen in genericList)
            {
                if (gen!.Equals(valueToFind))
                    counter++;
            }

            return counter switch
            {
                0 => default!,
                > 1 => throw new Exception("There is more than one match"),
                _ => valueToFind,
            };
        }

        public bool CheckIfExists(T valueToFind)
        {
            if(!genericList.Contains(valueToFind)) return false;
            else return true;
        }
    }
}
