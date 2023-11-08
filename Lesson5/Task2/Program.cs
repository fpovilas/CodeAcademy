namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2.1 Task\n2.2 Task\n2.3 Task");
            Console.Write("Enter you choice: ");
            byte choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Write a sentece: ");
                    string sentece = Console.ReadLine();

                    sentece = sentece.Replace("a", "uo");
                    sentece = sentece.Replace('i', 'e');

                    Console.WriteLine(sentece);
                    break;
                case 2:
                    Console.Write("Write a sentece\\peom or lyrics in one line: ");
                    sentece = Console.ReadLine();

                    Console.Write("What word do you like to change: ");
                    string wordToChange = Console.ReadLine();
                    Console.Write("What word do you like to change to: ");
                    string wordToChangeTo = Console.ReadLine();

                    sentece = sentece.Replace(wordToChange, wordToChangeTo);

                    Console.WriteLine(sentece);
                    break;
                case 3:
                    Console.Write("Please enter your birthdate: ");
                    string birthDate = Console.ReadLine();

                    if(birthDate.Contains('.') && !birthDate.Contains(" "))
                    {
                        int year = Convert.ToInt32(birthDate.Substring(0, 4));
                        int month = Convert.ToInt32(birthDate.Substring(5, 2));
                        int day = Convert.ToInt32(birthDate.Substring(8, 2));

                        DateTime timeWhenTurn90 = new DateTime(year + 90, month, day);
                        TimeSpan timeTill90 = timeWhenTurn90 - DateTime.Now;

                        Console.WriteLine($"Time left till you turn 90 years: {new DateTime() + timeTill90}"); // Neteisingai reikia peržiūrėti
                    }
                    else
                    {
                        Console.WriteLine("Please write date birth using this pattern yyyy.MM.dd");
                    }

                    break;
                default:
                    Console.WriteLine("There is only 3 choices");
                    break;
            }
        }
    }
}