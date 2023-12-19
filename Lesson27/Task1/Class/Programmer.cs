namespace Task1.Class
{
    internal class Programmer : Employee
    {
        private string ProgrammingLanguage { get; set; }

        public Programmer (string name, double salary, string programmingLanguage)
        {
            SetName(name);
            SetSalary(salary);
            ProgrammingLanguage = programmingLanguage;
        }

        public string GetProgrammingLanguage() => ProgrammingLanguage;

        public void SetProgrammingLanguage(string programmingLanguage)
        { ProgrammingLanguage = programmingLanguage; }
    }
}
