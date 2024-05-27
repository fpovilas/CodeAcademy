using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            Student student = new();
            student.SetName("Povilas");
            student.SetAge(10);
            Console.WriteLine(student.GetStudentID());

            Teacher studentTeacher = new();
            studentTeacher.SetName("Vardas");
            studentTeacher.SetSubject("Physics");
            Console.WriteLine($"Teacher {studentTeacher.GetName()}" +
                $" is teaching {studentTeacher.GetSubject()}");

        }
    }
}

/*
 * Create a class called "Person" with private fields "name" and "age".
 * You can access and set access to these fields using properties
 * with accessibility modifiers "public" and "private" respectively.
 * 
 * Extend the Person class from the previous exercise by adding a
 * protected method called "PrintInfo()", which prints the person's name and age.
 * 
 * Create a class called "Student" as a derived class from "Person".
 * Access to the "name" and "age" fields should be through protected properties.
 * Add a new private property "studentId" and a public method called "GetStudentId()"
 * which returns the student's identification number.
 * 
 * Create another class called "Teacher". Access to the "name" and "age" fields
 * should be through protected properties. Add a new private property "subject" and
 * a public method called "GetSubject()" which returns the name of the subject to be taught.
 */