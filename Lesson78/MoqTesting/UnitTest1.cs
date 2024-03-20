using DatabaseExam.Database;
using DatabaseExam.Database.Models;
using DatabaseExam.Repository;
using DatabaseExam.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MoqTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetStudent()
        {
            var students = new List<Student>()
            {
                new()
                {
                    Id = 420,
                    FirstName = "Test",
                    LastName = "Tested",
                    DepartmentId = 10000
                },
                new()
                {
                    Id = 421,
                    FirstName = "Bops",
                    LastName = "Bobber",
                    DepartmentId = 10002
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Student>>();
            var mockContext = new Mock<StudentISContext>(new DbContextOptions<StudentISContext>());

            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(students.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(students.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(students.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(students.GetEnumerator());

            mockContext.Setup(s => s.Students).Returns(mockSet.Object);

            var mockedStudentRepo = new StudentRepository(mockContext.Object);

            var result = mockedStudentRepo.GetStudentByID(420);

            Assert.AreEqual(students.FirstOrDefault(), result);
        }

        [TestMethod]
        public void TestAddingStudent()
        {
            var studentBops = new Student
            {
                Id = 421,
                FirstName = "Bops",
                LastName = "Bobber",
                DepartmentId = 10002
            };

            var mockOfAddStudent = new Mock<IStudentRepository>();

            mockOfAddStudent.Setup(s => s.AddStudent(studentBops)).Returns(studentBops.Id);

            var validation = mockOfAddStudent.Object;

            var result = validation.AddStudent(studentBops);

            Assert.AreEqual(studentBops.Id, result);
        }

        [TestMethod]
        public void TestAddingDepartment()
        {
            var mockRepo = new Mock<IDepartmentRepository>();
            var department = new Department
            {
                Id = 10000,
                Name = "Department of Test",
                Lectures =
                [
                    new Lecture
                    {
                        Id = 1,
                        Name = "Test"
                    }
                ],
                Students =
                [
                    new Student
                    {
                        Id = 1,
                        FirstName = "Test",
                        LastName = "Test",
                        DepartmentId = 10000
                    }
                ]
            };

            mockRepo.Setup(s => s.AddDepartment(department)).Returns(department.Id);

            var validation = mockRepo.Object;

            var result = validation.AddDepartment(department);

            Assert.AreEqual(department.Id, result);
        }

        [TestMethod]
        public void TestAddingLecture()
        {
            var mockRepo = new Mock<ILectureRepository>();
            var lecture = new Lecture
            { 
                Id = 1,
                Name = "Test",
                Departments = [],
                Students = []
            };

            mockRepo.Setup(s => s.AddLecture(lecture)).Returns(lecture.Id);

            var validation = mockRepo.Object;

            var result = validation.AddLecture(lecture);

            Assert.AreEqual(lecture.Id, result);
        }

        [TestMethod]
        public void TestRemoveLecture()
        {
            var mockRepo = new Mock<ILectureRepository>();

            var validation = mockRepo.Object;

            validation.DeleteLectureByID(1);

            mockRepo.Verify(s => s.DeleteLectureByID(1), Times.Once());
        }
    }
}