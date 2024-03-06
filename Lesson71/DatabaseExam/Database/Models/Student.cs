using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseExam.Database.Models
{
    internal class Student
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? LastName { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public virtual List<Lecture>? Lectures { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
