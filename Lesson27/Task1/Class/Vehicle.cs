namespace Task1.Class
{
    internal class Vehicle
    {
        private int Speed { get; set; }

        public Vehicle() { Speed = 0; }

        public void SetSpeed(int speed) { Speed = speed; }

        public int GetSpeed() { return Speed; }
    }
}
