using DatabaseExam.Database;
using DatabaseExam.Database.Models;
using DatabaseExam.Helpers;
using DatabaseExam.Repository;
using DatabaseExam.Repository.Interface;

namespace DatabaseExam.Presentation
{
    internal class ConsoleUI
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly IStudentRepository studentRepository;

        public ConsoleUI()
        {
            StudentISContext studentISContext = new();
            departmentRepository = new DepartmentRepository(studentISContext);
            lectureRepository = new LectureRepository(studentISContext);
            studentRepository = new StudentRepository(studentISContext);
        }

        public void Run()
        {
            // PopulateDepartments();
            // PopulateLectures();
            // PopulateStudents();

            CreateDepartmentWithStudentsAndLectures();

        }

        #region Initial Population Methods

        private void PopulateDepartments()
        {
            #region Departments

            Department depOfEngineering = new()
            {
                Name = "Department of Engineering"
            };
            Department depOfIT = new()
            {
                Name = "Department of Information Technologies"
            };
            Department depOfProgramming = new()
            {
                Name = "Department of Programming"
            };

            #endregion

            List<Department> departments = [depOfEngineering, depOfIT, depOfProgramming];

            foreach (Department department in departments)
            {
                Console.WriteLine($"Adding {department} to database");
                departmentRepository.AddDepartment(department);
            }
        }

        private void PopulateLectures()
        {
            #region Lectures

            Lecture lectureCAD = new()
            {
                Name = "CAD"
            };

            Lecture lectureMath = new()
            {
                Name = "Math"
            };

            Lecture lectureCSharp = new()
            {
                Name = "Programming C#"
            };

            #endregion

            List<Lecture> lectures = new() { lectureCSharp, lectureMath, lectureCAD };

            foreach (Lecture lecture in lectures)
            {
                Console.WriteLine($"Adding {lecture} to database");
                lectureRepository.AddLecture(lecture);
            }
        }

        private void PopulateStudents()
        {
            #region Students

            Student studentPovilasP = new()
            {
                FirstName = "Povilas",
                LastName = "Povka"
            };

            Student studentIeva = new()
            {
                FirstName = "Ieva",
                LastName = "Ievute"
            };

            Student studentLukas = new()
            {
                FirstName = "Lukas",
                LastName = "Apa"
            };

            #endregion

            List<Student> students = [studentPovilasP, studentIeva, studentLukas];

            foreach (Student student in students)
            {
                Console.WriteLine($"Adding {student} to database");
                studentRepository.AddStudent(student);
            }
        }

        #endregion

        #region Print

        public void PrintAllStudents()
        {
            Console.Clear();
            List<Student> students = studentRepository.GetAllStudents();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i]}");
            }
        }

        public void PrintAllLectures()
        {
            Console.Clear();
            List<Lecture> lectures = lectureRepository.GetAllLectures();
            for (int i = 0; i < lectures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lectures[i]}");
            }
        }

        #endregion

        public Department CreateDepartment()
        {
            Department department = new();
            string? depName;
            do
            {
                Console.Clear();
                Console.Write("Write department name: ");
                depName = Console.ReadLine();
                if (!string.IsNullOrEmpty(depName))
                {
                    if (depName.Contains("Department of") && depName[("Department of").Length] == ' ')
                    {
                        department.Name = depName;
                    }
                    else
                    {
                        ColorfulPrint.RedWriteLine("Department name does not contain string \"Department of \" or it is written wrong");
                        Console.ReadKey(true);
                        depName = string.Empty;
                    }
                }
            } while (string.IsNullOrEmpty(depName));

            return department;
        }

        public void CreateDepartmentWithStudentsAndLectures()
        {
            Department department = CreateDepartment();
            List<Student> students = SelectStudents();
            List<Lecture> lectures = SelectLectures();
            department.Students = students;
            department.Lectures = lectures;

            departmentRepository.AddDepartment(department);
        }

        public List<Student> SelectStudents()
        {
            List<Student> students = [];
            bool stop = false;
            do
            {
                PrintAllStudents();
                int studentNum = Getter.ChoiceInt();
                if (studentNum == -1)
                {
                    ColorfulPrint.RedWriteLine("Wrong choice");
                    Console.ReadKey(true);
                }
                else
                {
                    students.Add(studentRepository.GetAllStudents()[studentNum - 1]);
                    Console.WriteLine("Stop selection(y/n):");
                    string stopLoop = Console.ReadLine() ?? "";
                    if(stopLoop.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                        stop = true;
                }
            } while (!stop);
            return students;
        }

        public List<Lecture> SelectLectures()
        {
            List<Lecture> lectures = [];
            bool stop = false;
            do
            {
                PrintAllLectures();
                int lectureNum = Getter.ChoiceInt();
                if (lectureNum == -1)
                {
                    ColorfulPrint.RedWriteLine("Wrong choice");
                    Console.ReadKey(true);
                }
                else
                {
                    lectures.Add(lectureRepository.GetAllLectures()[lectureNum - 1]);
                    Console.WriteLine("Stop selection(y/n):");
                    string stopLoop = Console.ReadLine() ?? "";
                    if (stopLoop.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                        stop = true;
                }
            } while (!stop);
            return lectures;
        }
    }
}
