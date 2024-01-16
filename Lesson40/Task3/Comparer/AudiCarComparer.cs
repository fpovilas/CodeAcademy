using Task2.Class;

namespace Task3.Comparer
{
    internal class AudiCarComparer : IComparer<AudiCar>
    {
        public int Compare(AudiCar? x, AudiCar? y)
        {
            if(x?.Fuel <  y?.Fuel) return 1;
            if(x?.Fuel > y?.Fuel) return -1;
            return 0;
        }
    }
}
