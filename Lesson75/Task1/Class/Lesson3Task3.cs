namespace Task1.Class
{
    public class Lesson3Task3
    {
        public string SubTask1(int hour)
        {
            if (hour >= 0 && hour < 12)
                return ("Good morning!");
            else if (hour >= 12 && hour < 18)
                return ("Good afternoon!");
            else if (hour >= 18 && hour < 24)
                return ($"Good evening!");
            else return ("Wrong time entered. Please enter only hours");
        }

        public string SubTask2(string pass)
        {
            if (pass == "Laikinas123" || pass == "Mellon")
                return ("You have successfully logged in");
            else if (pass == "01101001 01101110")
                return ("Hacked..");
            else return ("Password is incorrect, please try again..");
        }
    }
}
