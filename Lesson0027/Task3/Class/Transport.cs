namespace Task3.Class
{
    internal class Transport
    {
        private int Speed { get; set; }

        public void SetSpeed(int speed) { Speed = speed; }

        public int GetSpeed() { return Speed; }

        public virtual int MeasureSpeed()
        { return Speed; }
    }
}
