namespace Task3.Class
{
    internal class Employee
    {
        public string Name { get; set; } = string.Empty;

        public virtual void Greeting()
        {
            Console.WriteLine($"Hello I'm {Name}");
        }
    }
}

/*
 * Create a base class called "Employee"
 * with the virtual method "Greeting()".
 * Implement this method by returning a standard
 * greeting message. Create an object from the
 * "Employee" class and call the "Greeting()" method.
 * 
 * Extend the Employee class from the previous exercise
 * by creating an inherited class called Manager that
 * overrides the virtual method Greeting(). Implement this
 * method by returning the manager's greeting message.
 * Create an object from the "Manager" class and call the
 * "Greeting()" method.

*/