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

            //CreateDepartmentWithStudentsAndLectures();
            //AddStudentsToDepartment();
            //AddLecturesToDepartment();
            //CreateALectureAndAssignToDepartment();
            //CreateStudentAndAddToExistingDepartmentAndLectures();
            //TransferStudentToOtherDepartment();
            //DisplayAllStudentsInDepartment();
            //DisplayAllLecturesInDepartment();
            //DisplayAllLectureByStudent();

            //CreateLecture();

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

        private void PrintAllStudents()
        {
            Console.Clear();
            List<Student> students = studentRepository.GetAllStudents();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i]}");
            }
        }

        private void PrintAllLectures()
        {
            Console.Clear();
            List<Lecture> lectures = lectureRepository.GetAllLectures();
            for (int i = 0; i < lectures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lectures[i]}");
            }
        }

        #endregion

        #region Selection

        private List<Student> SelectStudents()
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
                    if (stopLoop.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                        stop = true;
                }
            } while (!stop);
            return students;
        }

        private List<Lecture> SelectLectures()
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

        #endregion

        #region Model Creation

        private Department CreateDepartment()
        {
            Department department = new()
            {
                Name = string.Empty,
                Lectures = [],
                Students = []
            };

            #region Creating Department Name

            string depName;
            bool stopLoop = false;
            do
            {
                depName = Getter.GetString("Write department name: ");
                if(CheckDepartmentForm(depName))
                {
                    department.Name = depName;
                    stopLoop = true;
                }
            } while (!stopLoop);

            #endregion

            #region Adding Lecture(s) to Department

            bool addLecturesToDepartment = Getter.GetBoolValue("Do you want add lectures to department? (y/n) ");
            List<Lecture> lectures = lectureRepository.GetAllLectures();
            while (addLecturesToDepartment)
            {
                Console.Clear();
                Console.WriteLine("Lectures:");
                foreach (Lecture lecture in lectures)
                {
                    if (!department.Lectures.Contains(lecture))
                        Console.WriteLine($"\t- ({lecture.Id}) {lecture}");
                }
                int lecID = Getter.GetInt("Enter lecture ID: ");
                if (!lectures.Any(lec => lec.Id.Equals(lecID)))
                {
                    ColorfulPrint.RedWriteLine("Lecture does not exist");
                    Console.ReadKey(true);
                }
                else
                {
                    department.Lectures.Add(lectures.FirstOrDefault(lID => lID.Id == lecID)!);
                    if (department.Lectures.Count != lectures.Count)
                    {
                        bool stopWhile = Getter.GetBoolValue("Do you want to stop selection? (y/n) ");
                        if (stopWhile) { addLecturesToDepartment = false; }
                    }
                    else { addLecturesToDepartment = false; }
                }
            }

            #endregion

            #region Adding Student(s) to Department

            bool addStudentsToDepartment = Getter.GetBoolValue("Do you want assign students to department? (y/n) ");
            List<Student> students = studentRepository.GetAllStudents();
            while (addStudentsToDepartment)
            {
                Console.Clear();
                Console.WriteLine("Students:");
                foreach (Student student in students)
                {
                    if (!department.Students.Contains(student) && student.Department is null)
                        Console.WriteLine($"\t- ({student.Id}) {student}");
                }
                int studID = Getter.GetInt("Enter lecture ID: ");
                if (!students.Any(stud => stud.Id.Equals(studID)))
                {
                    ColorfulPrint.RedWriteLine("Student does not exist");
                    Console.ReadKey(true);
                }
                else
                {
                    department.Students.Add(students.FirstOrDefault(lID => lID.Id == studID)!);
                    if (department.Students.Count != students.Count)
                    {
                        bool stopWhile = Getter.GetBoolValue("Do you want to stop selection? (y/n) ");
                        if (stopWhile) { addStudentsToDepartment = false; }
                    }
                    else { addStudentsToDepartment = false; }
                }
            }

            #endregion

            return department;
        }

        private Lecture CreateLecture()
        {
            Lecture lecture = new()
            {
                Name = string.Empty,
                Departments = [],
                Students = []
            };

            #region Create Lecture Name

            bool stopLoop = false;
            do
            {
                Console.Clear();
                string lectureName = Getter.GetString("Please enter lecture name: ");
                if (!lectureRepository.GetAllLectures().Exists(l => l.Name == lectureName))
                {
                    stopLoop = true;
                }
                else
                {
                    ColorfulPrint.RedWriteLine("Lecture already exists");
                    Console.ReadKey(true);
                }
            } while (!stopLoop);

            #endregion

            #region Add Department(s) to Lecture

            List<Department> departments = departmentRepository.GetAllDepartments();
            bool addDepartmentsToLecture = Getter.GetBoolValue("Do you want to assign lecture to departments? (y/n) ");
            while(addDepartmentsToLecture)
            {
                Console.Clear();
                Console.WriteLine("Departments: ");
                foreach (Department department in departments.Where(d => !lecture.Departments.Any(ld => ld.Id == d.Id)))
                {
                    Console.WriteLine($"\t- ({department.Id}) {department}");
                }
                int departmentID = Getter.GetInt("Enter department ID: ");
                if (!departments.Any(dep => dep.Id.Equals(departmentID)))
                {
                    ColorfulPrint.RedWriteLine("Department does not exist");
                    Console.ReadKey(true);
                }
                else
                {
                    lecture.Departments.Add(departments.FirstOrDefault(dID => dID.Id == departmentID)!);
                    if (lecture.Departments.Count != departments.Count)
                    {
                        bool stopWhile = Getter.GetBoolValue("Do you want to stop selection? (y/n) ");
                        if (stopWhile) { addDepartmentsToLecture = false; }
                    }
                    else { addDepartmentsToLecture = false; }
                }
            }

            #endregion

            #region Assign Student(s) to Lecture

            List<Student> students = studentRepository.GetAllStudents();
            bool addStudentsToLecture = Getter.GetBoolValue("Do you want to assign students to lecture? (y/n) ");
            while (addStudentsToLecture)
            {
                Console.Clear();
                Console.WriteLine("Students: ");
                foreach (Student student in students.Where(s => lecture.Departments.Any(d => d.Id == s.DepartmentId)))
                {
                    Console.WriteLine($"\t- ({student.Id}) {student}");
                }
                int studentID = Getter.GetInt("Enter student ID: ");
                if(students.Exists(s => s.Id == studentID))
                    lecture.Students.Add(studentRepository.GetStudentByID(studentID));
                else
                {
                    ColorfulPrint.RedWriteLine("Student does not exist");
                    Console.ReadKey(true);
                }
            }

            #endregion

            return lecture;
        }

        private Student CreateStudent()
        {
            Student student = new()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Department = new(),
                Lectures = []
            };

            student.FirstName = Getter.GetString("Enter student First Name: ");
            student.LastName = Getter.GetString("Enter student Last Name: ");

            bool assignDepartment = Getter.GetBoolValue("Do you want to assign department from existing ones?(y/n): ");
            if (assignDepartment)
            {
                Console.WriteLine("Departments: ");
                foreach (Department department in departmentRepository.GetAllDepartments())
                {
                    Console.WriteLine($"\t- ({department.Id}) {department}");
                }
                int departmentID = Getter.GetInt("Enter department ID: ");
                student.Department = departmentRepository.GetDepartmentByID(departmentID);

                student.Lectures = departmentRepository.GetDepartmentByID(departmentID).Lectures;
            }

            bool assignLectures = Getter.GetBoolValue("Do you want to assign lectures?(y/n): ");
            if (assignLectures)
            {
                Console.WriteLine("Lectures that you inherited from department:");
                foreach(Lecture lecture in student.Lectures!)
                {
                    Console.WriteLine($"\t- ({lecture.Id}) {lecture}");
                }

                Console.WriteLine("Possible lectures to choose: ");
                foreach (Lecture lecture in lectureRepository.GetAllLectures())
                {
                    if(!student.Lectures.Contains(lecture))
                        Console.WriteLine($"\t- ({lecture.Id}) {lecture}");
                }
            }

            return student;
        }

        #endregion

        private bool CheckDepartmentForm(string depName)
        {
            if (depName.Contains("Department of") && depName[("Department of").Length] == ' ')
            {
                if (!departmentRepository.GetAllDepartments().Any(dep => dep.Name == depName))
                    return true;
                else
                {
                    ColorfulPrint.RedWriteLine($"{depName} already exists");
                    Console.ReadKey(true);
                    return false;
                }
            }
            else
            {
                ColorfulPrint.RedWriteLine("Department name does not contain string \"Department of \" or it is written wrong");
                Console.ReadKey(true);
                return false;
            }
        }

        #region Task specific functions

        private void CreateDepartmentWithStudentsAndLectures()
        {
            Department department = CreateDepartment();
            List<Student> students = SelectStudents();
            List<Lecture> lectures = SelectLectures();
            department.Students = students;
            department.Lectures = lectures;

            departmentRepository.AddDepartment(department);
        }

        private void AddStudentsToDepartment()
        {
            List<Student> students =
            [
                new()
                {
                    FirstName = "Petras",
                    LastName = "Petrauskas"
                },
                new()
                {
                    FirstName = "Marytė",
                    LastName = "Marta"
                }
            ];

            Department department = departmentRepository.GetDepartmentByName("Department of Programming");
            department.Students = students;

            departmentRepository.UpdateDepartment(department);
        }

        private void AddLecturesToDepartment()
        {
            List<Lecture> lectures =
            [
                new()
                {
                    Name = "Physics"
                },
                new()
                {
                    Name = "Architecture"
                }
            ];

            Department department = departmentRepository.GetDepartmentByName("Department of Engineering");
            department.Lectures = lectures;

            departmentRepository.UpdateDepartment(department);
        }

        private void CreateALectureAndAssignToDepartment()
        {
            Lecture lecturePhilosophy = new()
            {
                Name = "Philosophy"
            };

            Department departmentOfProgramming = departmentRepository.GetDepartmentByName("Department of Programming");
            departmentOfProgramming.Lectures = [lecturePhilosophy];

            departmentRepository.UpdateDepartment(departmentOfProgramming);
        }

        private void CreateStudentAndAddToExistingDepartmentAndLectures()
        {
            Student studentGediminas = new()
            {
                FirstName = "Gediminas",
                LastName = "Gediminaitis"
            };

            Department department = departmentRepository.GetDepartmentByID(10002);
            if(department.Students is not null)
                department.Students!.Add(studentGediminas);
            else { department.Students = [studentGediminas]; }
            departmentRepository.UpdateDepartment(department);

            List<Lecture> lectures =
                [
                    lectureRepository.GetLectureByID(2),
                    lectureRepository.GetLectureByID(4),
                    lectureRepository.GetLectureByID(6),
                ];

            foreach (Lecture l in lectures)
            {
                if(l.Students is null)
                    l.Students = [studentGediminas];
                else
                {
                    if(!l.Students.Contains(studentGediminas))
                        l.Students.Add(studentGediminas);
                }
                lectureRepository.UpdateLecture(l);
            }
            
        }

        private void TransferStudentToOtherDepartment()
        {
            Student student = studentRepository.GetStudentByID(424);
            Department department = departmentRepository.GetDepartmentByID(10000);
            List<Lecture> lectures = [];

            student.Department = department;

            if (department.Lectures is not null)
            {
                foreach (Lecture depLecture in department.Lectures)
                {
                    if (student.Lectures is not null)
                    {
                        foreach (Lecture studLecture in student.Lectures)
                        {
                            if (studLecture == depLecture)
                                lectures.Add(studLecture);
                        }
                    }
                }

                student.Lectures = lectures;
            }
            else { student.Lectures = department.Lectures; }

            studentRepository.UpdateStudent(student);
        }

        private void DisplayAllStudentsInDepartment()
        {
            const string depName = "Department of Engineering";

            Console.WriteLine($"All students in Department of Engineering:");
            foreach (Student student in departmentRepository.GetDepartmentByName(depName).Students ?? [])
            {
                Console.WriteLine($"\t- ({student.Id}) {student}");
            }
        }

        private void DisplayAllLecturesInDepartment()
        {
            const int depID = 10000;

            Console.WriteLine($"All lectures in Department of Engineering:");
            foreach (Lecture lecture in departmentRepository.GetDepartmentByID(depID).Lectures ?? [])
            {
                Console.WriteLine($"\t- ({lecture.Id}) {lecture}");
            }
        }

        private void DisplayAllLectureByStudent()
        {
            Console.WriteLine("All lectures that Students have:");
            foreach(Student student in studentRepository.GetAllStudents())
            {
                int index = 0;
                Console.WriteLine($"\t- ({student.Id}) {student}:");
                List<Lecture> lectures = student.Lectures ?? [];

                if (student.Lectures is not null)
                {
                    do
                    {
                        if (student.Lectures.Count > 0)
                            Console.WriteLine($"\t\t- ({lectures[index].Id}) {lectures[index]}");
                        else { Console.WriteLine("\t\t No lectures"); }
                        index++;
                    } while (student.Lectures.Count > 0 && student.Lectures.Count > index);
                }
                //foreach(Lecture lecture in student.Lectures ?? [])
                //{
                //    if (student.Lectures is not null)
                //        Console.WriteLine($"\t\t- ({lecture.Id}) {lecture}");
                //    else { Console.WriteLine("\t\t No lectures"); }
                //}
            }
        }

        #endregion
    }
}