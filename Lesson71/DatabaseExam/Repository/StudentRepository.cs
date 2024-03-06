using DatabaseExam.Database.Models;
using DatabaseExam.Database;
using DatabaseExam.Repository.Interface;

namespace DatabaseExam.Repository
{
    internal class StudentRepository(StudentISContext context) : IStudentRepository
    {
        private readonly StudentISContext studentISContext = context;

        public int AddStudent(Student student)
        {
            studentISContext.Students.Add(student);
            studentISContext.SaveChanges();

            return studentISContext.Students.FirstOrDefault(dID => dID.Id == student.Id)!.Id;
        }

        public Student GetStudentByID(int studentId)
            => studentISContext.Students.FirstOrDefault(dID => dID.Id == studentId) ?? new();

        public List<Student> GetAllStudents() => studentISContext.Students.ToList();

        public void UpdateStudent(Student studentIn)
        {
            studentISContext.Students.Update(studentIn);
            studentISContext.SaveChanges();
        }

        public void DeleteStudentByID(int studentId)
        {
            studentISContext.Students.Remove(GetStudentByID(studentId));
        }
    }
}
