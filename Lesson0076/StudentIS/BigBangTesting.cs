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

        [TestMethod]
        public void DepartmentCreation_CreateDepartmentWithStudentsAndLectures_CreatedDepartmentWithStudentsAndLectures()
        {
            Department department = new()
            {
                Name = "Department of Math",
                Lectures =
                [
                    new Lecture()
                    {
                        Name = "Math"
                    },
                    new Lecture()
                    {
                        Name = "Physics"
                    }
                ],
                Students =
                [
                    new Student()
                    { 
                        FirstName = "Tester",
                        LastName = "Test",
                    }
                ]
            };

            departmentRepository.AddDepartment(department);

            var addedDepartment = departmentRepository.GetDepartmentByName(department.Name);

            Assert.IsNotNull(addedDepartment);
            Assert.IsTrue(addedDepartment.Lectures.Count > 0);
            Assert.IsTrue(addedDepartment.Students.Count > 0);
        }

        [TestMethod]
        public void StudentTransfer_TransferStudentToOtherDepartment_StudentTransferredToOtherDepartment()
        {
            Student student = new()
            {
                Id = 420,
                FirstName = "Ieva",
                LastName = "Test",
                DepartmentId = 10000,
                Lectures =
                [
                    new Lecture
                    {
                        Id = 1,
                        Name = "Art",
                        Departments = [],
                        Students = []
                    }
                ]
            };

            // Old Department
            Department departmentOfArt = new()
            {
                Id = 10000,
                Name = "Department of Art",
                Lectures = student.Lectures,
                Students = [student]
            };

            // New Department
            Department departmentOfPhilosophy = new()
            {
                Id = 10002,
                Name = "Department of Philosophy",
                Lectures =
                [
                    new Lecture
                    {
                        Id = 2,
                        Name = "Philosophy"
                    }
                ],
                Students = []
            };

            departmentRepository.AddDepartment(departmentOfArt);
            departmentRepository.AddDepartment(departmentOfPhilosophy);

            student.DepartmentId = departmentOfPhilosophy.Id;

            studentRepository.UpdateStudent(student);

            Assert.IsTrue(studentRepository.GetStudentByID(student.Id).DepartmentId == departmentOfPhilosophy.Id);
        }

        [TestMethod]
        public void StudentDepartment_CreateStudentAndAddToExistingDepartmentAndLectures_StudentAddedToDepartmentAndLectures()
        {
            Student studentGediminas = new()
            {
                Id = 500,
                FirstName = "Gediminas",
                LastName = "Gediminaitis"
            };

            studentRepository.AddStudent(studentGediminas);

            Department departmentOfPhilosophy = new()
            {
                Id = 10002,
                Name = "Department of Philosophy",
                Lectures =
                [
                    new Lecture
                    {
                        Id = 2,
                        Name = "Philosophy"
                    }
                ],
                Students = []
            };

            departmentOfPhilosophy.Students.Add(studentGediminas);

            departmentRepository.AddDepartment(departmentOfPhilosophy);

            // Check if student has Department
            Assert.IsTrue(studentRepository.GetStudentByID(500).DepartmentId == 10002);

            List<Lecture> lectures =
                [
                    new Lecture
                    {
                        Id = 4,
                        Name = "Rhetoric",
                    },
                    new Lecture
                    {
                        Id = 5,
                        Name = "Psychology"
                    }
                ];

            foreach (Lecture l in lectures)
            {
                if(!lectureRepository.GetAllLectures().Contains(l))
                    lectureRepository.AddLecture(l);

                if (l.Students is null)
                    l.Students = [studentGediminas];
                else
                {
                    if (!l.Students.Contains(studentGediminas))
                        l.Students.Add(studentGediminas);
                }
                lectureRepository.UpdateLecture(l);
            }

            Assert.IsTrue(studentRepository.GetStudentByID(500).Lectures.Count() > 0);
            Assert.AreNotEqual(studentRepository.GetStudentByID(500).Lectures, departmentRepository.GetDepartmentByID(10002).Lectures);

        }

        [TestCleanup]
        public void CleanUp()
        {
            context!.Database.EnsureDeleted();
        }
    }
}
