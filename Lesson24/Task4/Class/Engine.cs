namespace Task4.Class
{
    internal class Engine
    {
        public bool State {  get; set; }

        public Engine()
        {
            State = false;
        }

        public string EngineState()
        {
            if (State) { return "ON"; }
            else { return "OFF"; }
        }
    }
}
