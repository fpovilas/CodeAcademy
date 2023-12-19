namespace Task4.Class
{
    internal class Rectangle : Shape
    {
        public int Lenght { get; set; } = 0;
        public int Height { get; set; } = 0;

        public override void Draw()
        {
            Console.WriteLine("""
                ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                ▓▓                              ▓▓
                ▓▓                              ▓▓
                ▓▓                              ▓▓
                ▓▓                              ▓▓
                ██                              ▓▓
                ████████████████████████████████▓▓
                """);
            Console.WriteLine($"Height: {Height} Lenght: {Lenght}");
        }
    }
}
