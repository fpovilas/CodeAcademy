using Task2.Interface;

namespace Task2.Comparer
{
    internal class IPolygonComparer : IComparer<IPolygon>
    {
        public int Compare(IPolygon? x, IPolygon? y)
        {
            if(x == null || y == null) return 0;
            if(x.GetArea() < y.GetArea()) return -1;
            if (x.GetArea() > y.GetArea()) return 1;
            return 0;
        }
    }
}
