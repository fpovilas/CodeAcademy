namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("""
                Bread:
                    Whole - 0.75 Eur
                    White - 0.25 Eur
                Meat:
                    Chicken - 1.5 Eur
                    Pork - 1 Eur
                    Bacon - 1.25 Eur
                Cheese:
                    Fetta - 0.25 Eur
                    American - 0.1 Eur
                Vegetables:
                    Tomatoes - 0.15 Eur
                    Cabage - 0.05 Eur
                    Cucumber - 0.1 Eur
                Sauce:
                    Mix - 0.7 Eur
                    Chilli - 0.5 Eur
                    Garlic - 0.5 Eur
                """);

            double breadPrice, meatPrice, cheesePrice, veg1Price, veg2Price, saucePrice, sandwitchPrice;
            breadPrice = meatPrice = cheesePrice = veg1Price = veg2Price = saucePrice = sandwitchPrice = 0;
            bool isWrong = false;
            bool isAllItemChosen = false;

            // Bread choice
            Console.Write("Please chooce your bread: ");
            string bread = Console.ReadLine();
            if (bread.ToLower()  == "whole")
                meatPrice = 0.75;
            else if (bread.ToLower() == "white")
                meatPrice = 0.25;
            else { isWrong = true; }

            // Meat choice
            if (!isWrong)
            {
                Console.Write("Please chooce your meat: ");
                string meat = Console.ReadLine();

                switch (meat.ToLower())
                {
                    case "chicken":
                        meatPrice = 1.5;
                        break;
                    case "pork":
                        meatPrice = 1;
                        break;
                    case "bacon":
                        meatPrice = 1.25;
                        break;
                    default:
                        isWrong = true;
                        break;
                }
            }
            else { isWrong = true; }

            // Cheese choice
            if (!isWrong)
            {
                Console.Write("Please chooce your cheese: ");
                string cheese = Console.ReadLine();

                switch (cheese.ToLower())
                {
                    case "fetta":
                        cheesePrice = 0.25;
                        break;
                    case "american":
                        cheesePrice = 0.1;
                        break;
                    default:
                        isWrong = true;
                        break;
                }
            }
            else { isWrong = true; }

            // Vegetable choice
            if (!isWrong)
            {
                Console.Write("Please chooce your 1st vegetable: ");
                string veg1 = Console.ReadLine();
                switch (veg1.ToLower())
                {
                    case "tomatoes":
                        veg1Price = 0.15;
                        break;
                    case "cabage":
                        veg1Price = 0.05;
                        break;
                    case "cucumber":
                        veg1Price = 0.1;
                        break;
                    default:
                        isWrong = true;
                        break;
                }
                Console.Write("Please chooce your 2nd vegetable: ");
                string veg2 = Console.ReadLine();
                switch (veg2.ToLower())
                {
                    case "tomatoes":
                        veg2Price = 0.15;
                        break;
                    case "cabage":
                        veg2Price = 0.05;
                        break;
                    case "cucumber":
                        veg2Price = 0.1;
                        break;
                    default:
                        isWrong = true;
                        break;
                }
            }
            else { isWrong = true; }

            // Sauce choice
            if (!isWrong)
            {
                Console.Write("Please chooce your sauce: ");
                string sauce = Console.ReadLine();
                switch (sauce.ToLower())
                {
                    case "mix":
                        saucePrice = 0.7;
                        break;
                    case "chilli":
                        saucePrice = 0.5;
                        break;
                    case "garlic":
                        saucePrice = 0.5;
                        break;
                    default:
                        isWrong = true;
                        break;
                }
                isAllItemChosen = true;
            }
            else
            {
                Console.WriteLine("You have not chosen something wrong");
            }

            if (isAllItemChosen)
            {
                sandwitchPrice = breadPrice + meatPrice + cheesePrice + veg1Price + veg2Price + saucePrice;
                Console.WriteLine($"\nSandwitch price: {sandwitchPrice:#.##} Eur ");
            }
        }
    }
}