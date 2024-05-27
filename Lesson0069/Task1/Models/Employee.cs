namespace Task1.Models
{
    internal class Employee
    {
        public required string PersonalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Position { get; set; }
        public string? DepartmentName { get; set; }
        public int? ProjectID { get; set; }

        public override string ToString()
        {
            return $"{PersonalCode} {FirstName} {LastName} {StartDate} {BirthDate} {Position} {DepartmentName} {ProjectID}";
        }
    }
}
