namespace Task1.Model
{
    internal class Head
    {
        public HeadType HeadT { get; set; }

        public enum HeadType
        {
            Square = 0,
            Triangle = 1,
            Round = 2,
            Oblong = 3
        };
    }
}
