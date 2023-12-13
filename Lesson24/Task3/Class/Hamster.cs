namespace Task3.Class
{
    internal class Hamster
    {
        public string Name { get; set; }

        public Hamster()
        {
            Name = string.Empty;
        }
        public Hamster(string name)
        {
            Name = name;
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello my name is {Name} and I'm Hamster");
        }
    }
}
