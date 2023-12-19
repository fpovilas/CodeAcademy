namespace Task1.Class
{
    internal class Employee
    {
        private string Name { get; set; }
        private double Salary { get; set; }

        public Employee()
        {
            Name = string.Empty;
            Salary = 0;
        }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public void SetName(string name) { Name = name; }

        public void SetSalary(double salary) {  Salary = salary; }

        public string GetName() => Name;

        public double GetSalary() => Salary;
    }
}
