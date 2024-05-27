namespace Task4.Class
{
    internal class Shape
    {
        public int Corners { get; set; } = 0;

        public virtual void Draw()
        {
            Console.WriteLine(Corners);
        }
    }
}
