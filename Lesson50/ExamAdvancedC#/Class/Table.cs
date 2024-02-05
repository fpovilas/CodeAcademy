namespace ExamAdvancedCSharp.Class
{
    internal class Table(string name, int seating, Waitress? waitress = null)
    {
        private Waitress? Waitress { get; set; } = waitress;
        private string Name { get; set; } = name;
        private int Seating {  get; set; } = seating;
        private bool IsTaken { get; set; } = false;

        public Waitress? GetWaitress() => Waitress;
        public string GetTableName() => Name;
        public int GetSeating() => Seating;
        public bool GetTableState() => IsTaken;

        public bool SetTableSate(bool state) => IsTaken = state;

        public override string ToString()
            => $"{Name} has {Seating} seats and are served by" +
            $" {(Waitress != null ? Waitress.GetName() : "No one")}" +
            $" | {(IsTaken ? "Unavailable" : "Available")}";
    }
}
