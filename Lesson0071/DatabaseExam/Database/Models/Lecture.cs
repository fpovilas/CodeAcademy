using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseExam.Database.Models
{
    public class Lecture
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        public virtual List<Department>? Departments { get; set; }
        public virtual List<Student>? Students { get; set; }

        public override string ToString() => $"{Name}";
    }
}
