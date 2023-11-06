namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Apple - 1 Eur");
            Console.WriteLine("2. Milk - 3 Eur");
            Console.WriteLine("3. Crisps - 2 Eur");

            Console.Write("\nPlease choose 1st product: ");
            int firstItem = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please choose 2nd product: ");
            int secondItem = Convert.ToInt16(Console.ReadLine());

            int firstItemPrice = 0;
            int secondItemPrice = 0;

            if (firstItem == 1) firstItemPrice = 1;
            if (secondItem == 1) secondItemPrice = 1;
            if (firstItem == 2) firstItemPrice = 3;
            if (secondItem == 2) secondItemPrice = 3;
            if (firstItem == 3) firstItemPrice = 2;
            if (secondItem == 3) secondItemPrice = 2;

            double sum;
            bool hasLoyaltyCard = false;

            sum = firstItemPrice + secondItemPrice;

            if(firstItem == secondItem)
            {
                sum *= 0.9;

                Console.Write("\nDo you have loyalty card?(yes/no):" );
                string loyaltyCardAnswer = Console.ReadLine();

                if( loyaltyCardAnswer.ToLower() == "yes" )
                    hasLoyaltyCard = true;

                if (hasLoyaltyCard)
                    sum *= 0.9;
            }
            else
            {
                Console.Write("\nDo you have loyalty card?(yes/no):");
                string loyaltyCardAnswer = Console.ReadLine();

                if (loyaltyCardAnswer.ToLower() == "yes")
                    hasLoyaltyCard = true;

                if (hasLoyaltyCard)
                    sum *= 0.9;
            }

            Console.WriteLine($"\n======== Reciete ========\n" +
                              $"*  Total sum: {sum} Eur   *\n" +
                              $"=========================");
        }
    }
}