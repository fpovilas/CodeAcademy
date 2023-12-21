namespace Task1.Class
{
    internal class Student : Person
    {
        private string StudentID { get; set; }
                        = Guid.NewGuid().ToString();

        public string GetStudentID()
        {
            Console.Write($"{Name} ID is ");
            return StudentID;
        }
    }
}
