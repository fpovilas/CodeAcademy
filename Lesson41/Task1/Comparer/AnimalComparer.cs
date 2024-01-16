using Task1.Class;

namespace Task1.Comparer
{
    internal class AnimalComparer : IComparer<Bass>, IComparer<Carp>, IComparer<Cat>, IComparer<Dog>
    {
        public int Compare(Bass? x, Bass? y) => string.Compare(x?.GetName(), y?.GetName());

        public int Compare(Carp? x, Carp? y) => string.Compare(x?.GetName(), y?.GetName());

        public int Compare(Cat? x, Cat? y) => string.Compare(x?.GetName(), y?.GetName());

        public int Compare(Dog? x, Dog? y) => string.Compare(x?.GetName(), y?.GetName());
    }
}
