namespace Task1.Class
{
    internal class Manager : Employee
    {
        List<Employee> Employees { get; set; } = new List<Employee>();
        List<Programmer> ProgrammerEmployees { get; set; } = new List<Programmer>();

        public Manager(string name, double salary)
        {
            SetName(name);
            SetSalary(salary);
        }

        public void SetEmployees(List<Employee> employees) { Employees = employees; }

        public void SetEmployees(List<Programmer> programmerEmployees)
        { ProgrammerEmployees = programmerEmployees; }

        public void GetEmployees()
        {
            if (Employees.Capacity > 0)
            {
                foreach (Employee emp in Employees)
                {
                    Console.WriteLine($"\t{emp.GetName()}");
                }
            }
            else { Console.WriteLine("Manager does not have working people for him"); }
        }

        public void GetEmployees(bool isProgrammer)
        {
            {
                if (ProgrammerEmployees.Capacity > 0 && isProgrammer)
                {
                    foreach (Programmer emp in ProgrammerEmployees)
                    {
                        Console.WriteLine($"\t{emp.GetName()}");
                    }
                }
                else { Console.WriteLine("Manager does not have working people for him"); }
            }
        }

        public int GetEmployeesNumber() { return Employees.Count; }
        public int GetEmployeesNumber(bool isProgrammer) { return isProgrammer ? ProgrammerEmployees.Count : 0; }
    }
}
