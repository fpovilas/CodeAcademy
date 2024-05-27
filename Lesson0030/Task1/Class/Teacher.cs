namespace Task1.Class
{
    internal class Teacher : Person
    {
        private string Subject { get; set; } = string.Empty;

        public void SetSubject(string subject) { Subject = subject; }

        public string GetName() { return Name; }

        public int GetAge() { return Age; }

        public string GetSubject() => Subject;
    }
}
