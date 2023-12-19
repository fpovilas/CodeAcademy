namespace Task3.Class
{
    internal class Manager : Employee
    {
        public override void Greeting()
        {
            Console.WriteLine($"Hello I'm {Name}" +
                $" and I'm your manager");
        }
    }
}
