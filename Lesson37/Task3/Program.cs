using Task3.Class;

namespace Task3
{
    internal class Program
    {
        public delegate bool FilterDelegate(Person person);

        static void Main()
        {
            List<Person> people =
            [
                new("Leeroy", 92),
                new("Joan", 13),
                new("Jenkins", 88),
                new("John", 25)
            ];

            DisplayPeople("Children", people, IsChild);
            DisplayPeople("Adult", people, IsAdult);
            DisplayPeople("Senior", people, IsSenior);                
        }

        private static bool IsChild(Person person) => person.GetAge() < 18;

        private static bool IsAdult(Person person) => (person.GetAge() >= 18 && person.GetAge() < 65);

        private static bool IsSenior(Person person) => person.GetAge() >= 65;

        private static void DisplayPeople(string ageTitle, List<Person> people, FilterDelegate filterDelegate)
        {
            Console.WriteLine(ageTitle + ":");
            foreach (Person person in people)
            {
                if (filterDelegate(person))
                    Console.WriteLine(person.GetName());
            }
        }
    }
}
/*
 * Create a Person class with string name and int age
 * In the Main method, create a list of people with different names and ages
 * Create a Filter delegate that returns a bool and takes a Person object as a parameter.
 * Create three methods that will return bool values and accept Person as a parameter, one method will check if the person is a child < 18 years old, one will check if the person is an adult >= 18 years old and one will check if the person is a senior citizen >= 65 years old.
 * Create a DisplayPeople method, with title, List<Person> and Filter delegate. The essence of the method will be to loop through the persons and run a filter passed through the parameters to check if the person is, for example, a child.
 * 
 ** The method call will look something like this: displayPeople("Children:", people, IsChild);
 */