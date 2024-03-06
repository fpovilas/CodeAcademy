using DatabaseExam.Database.Models;

namespace DatabaseExam.Repository.Interface
{
    internal interface IStudentRepository
    {
        public int AddStudent(Student student);
        public Student GetStudentByID(int studentId);
        public void UpdateStudent(Student studentIn);
        public void DeleteStudentByID(int studentId);
        public List<Student> GetAllStudents();
    }
}
