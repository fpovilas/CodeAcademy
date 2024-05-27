namespace Task2.Class
{
    internal class GenericClass<T>(List<T> values)
    {
        private List<T> GenericValues { get; set; } = values;

        public void PrintList()
        {
            foreach (var genericValue in GenericValues)
            {
                Console.Write(genericValue + " ");
            }
            Console.WriteLine();
        }

        public T[] ConvertToArray() => GenericValues.ToArray();

        public void Add(T value) => GenericValues.Add(value);

        public void AddList(List<T> values) => GenericValues.AddRange(values);

        public void Remove(T value) => GenericValues.Remove(value);

        public void RemoveByIndex(int index) => GenericValues.RemoveAt(index);

        public void RemoveAllDuplicates(T valueToRemove)
        {
            List<int> toRemove = [];

            for (int i = 0; i < GenericValues.Count; i++)
            {
                if(valueToRemove!.Equals(GenericValues[i]))
                    toRemove.Add(i);
            }

            for (int i = 0; i < GenericValues.Count; i++)
                GenericValues.Remove(valueToRemove);
        }
    }
}
