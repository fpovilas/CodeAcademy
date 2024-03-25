namespace Task1.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DueDate { get; set; }
        public bool isDone { get; set; }
    }
}
