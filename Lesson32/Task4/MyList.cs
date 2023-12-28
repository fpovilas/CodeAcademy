namespace Task4
{
    internal class MyList<T>
    {
        private T[] MyArray { get; set; }
        private int Index = 0;
        private int Size = 10;

        public MyList()
        {
            MyArray = new T[Size];
        }

        public void AddElement(T item)
        {
            if (CheckIfFull())
                MyArray = IncreaseListSize();

            if(item != null)
            {
                MyArray[Index] = item;
                Index++;
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public void RemoveElement(T item)
        {
            int index = Array.IndexOf(MyArray, item);
            MyArray[index] = default(T);
            Index--;
            MyArray = SortArray();
        }

        private bool CheckIfFull()
        {
            if(Index == Size)
                return true;
            else
                return false;
        }

        private T[] IncreaseListSize()
        {
            Size += (Size / 2);
            var MyArray = new T[Size];
            MyArray.CopyTo(MyArray, 0);
            return MyArray;
        }

        private T[] SortArray()
        {
            T temp;
            for (int i = 0; i < Size; i++)
            {
                if (MyArray[i] == null && MyArray[i + 1] != null)
                {
                    temp = MyArray[i + 1];
                    MyArray[i] = temp;
                    MyArray[i + 1] = default(T);
                }
            }

            return MyArray;
        }
    }
}