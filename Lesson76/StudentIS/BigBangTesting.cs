using Microsoft.EntityFrameworkCore;
using DatabaseExam.Database;
using DatabaseExam.Repository.Interface;
using DatabaseExam.Repository;
using DatabaseExam.Database.Models;

namespace StudentISTest
{
    [TestClass]
    public class BigBangTesting
    {
        private StudentISContext? context;
        private IStudentRepository? studentRepository;
        private ILectureRepository? lectureRepository;
        private IDepartmentRepository? departmentRepository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<StudentISContext>()
                .UseInMemoryDatabase(databaseName: "TestStudentISDB")
                .Options;

            context = new StudentISContext(options);
            studentRepository = new StudentRepository(context);
            lectureRepository = new LectureRepository(context);
            departmentRepository = new DepartmentRepository(context);

            studentRepository.AddStudent(new Student() { Id = 1, FirstName = "Test", LastName = "Tester" });
        }

        /*
         * How unit test method should be named
         * // <method-modifier> <method-type> WhatIsTested(Feature)_Scenario_Expectation
         */

        [TestMethod]
        public void GetStudent_GetStudentByID_GetsStudentByID()
        {
            var student = studentRepository!.GetStudentByID(1);
            Assert.IsNotNull(student);
        }
        
        [TestMethod]
        public void AddingLectureToDepartment_CreateALectureAndAssignToDepartment_AddedLectureToADepartment()
        {
            Lecture lecturePhilosophy = new()
            {
                Name = "Philosophy"
            };

            //Check if department CREATED locally
            Department departmentOfMath = new()
            {
                Name = "Department of Math",
                Lectures = [],
                Students = []
            };
            
            departmentOfMath.Lectures = [lecturePhilosophy];

            departmentRepository.UpdateDepartment(departmentOfMath);

            //Check if department ADDED to DB

            var department = departmentRepository.GetDepartmentByName(departmentOfMath.Name);
            Assert.IsNotNull(department);

            //Check if lecture has been ADDED to department
            Assert.IsTrue(department.Lectures.Count > 0);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context!.Database.EnsureDeleted();
        }
    }
}
