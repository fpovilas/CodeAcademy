namespace ExamAdvancedCSharp.Class
{
    internal class Table(string name, int seating, Waiter? waiter = null)
    {
        private Waiter? Waitress { get; set; } = waiter;
        private string Name { get; set; } = name;
        private int Seating {  get; set; } = seating;
        private bool IsTaken { get; set; } = false;

        public Waiter? GetWaiter() => Waitress;
        public string GetTableName() => Name;
        public int GetSeating() => Seating;
        public bool GetTableState() => IsTaken;

        public void SetTableSate(bool state) => IsTaken = state;
        public void SetWaiter(Waiter? waiter)
        {
            Waitress = waiter;
            Waitress?.AddTable(this);
        }

        public override string ToString()
            => $"{Name} has {Seating} seats and are served by" +
            $" {(Waitress != null ? Waitress.GetName() : "No one")}" +
            $" | {(IsTaken ? "Unavailable" : "Available")}";
    }
}
