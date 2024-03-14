namespace Task1.Class
{
    public class Lesson3Task2
    {
        public string SubTask1(int num)
        {
            if (num % 2 == 0)
               return ($"The number {num} is even");
            else if (num % 5 == 0)
                return ($"The number {num} is divisable by 5");
            else return  ($"The number {num} does not meet any conditions");
        }

        public string SubTask2(int temp)
        {
            if (temp <= 0)
                return ("Cold");
            else if (temp > 0 && temp <= 20)
                return ("Cool");
            else return ("Hot");
        }
    }
}
