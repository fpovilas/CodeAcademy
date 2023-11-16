namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Povilas Frišmantas";
            int age = 26;
            string jobTitle = "Network engineer";
            string eMail = "f.povilas@gmail.com";
            string phoneNumber = "1234567890";

            Console.WriteLine("=============== Bussiness Card ===============");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Job Title: {jobTitle}");
            Console.WriteLine($"E. Mail: {eMail}");
            Console.WriteLine($"Phone No.: {phoneNumber}");
            Console.WriteLine("==============================================");
        }
    }
}