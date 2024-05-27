using Task2.Class;

namespace Task3.Comparer
{
    internal class BmwCarComparer : IComparer<BmwCar>
    {
        public int Compare(BmwCar? x, BmwCar? y)
        {
            return string.Compare(x?.Model, y?.Model);
        }
    }
}
