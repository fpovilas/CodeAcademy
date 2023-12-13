namespace Task4.Class
{
    internal class Car
    {
        public string Name { get; set; }
        public Engine Engine { get; set; }

        public Car(string name)
        {
            Engine = new();
            Name = name;
        }

        public void SetEngineState(bool state)
        {
            Engine.State = state;
        }

        public string GetEngineState()
        {
            return Engine.EngineState();
        }
    }
}
