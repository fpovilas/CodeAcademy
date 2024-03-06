using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseExam.Database.Models
{
    internal class Department
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        public virtual List<Student>? Students { get; set; }

        public virtual List<Lecture>? Lectures { get; set; }

        public override string ToString() => $"{Name}";
    }
}
