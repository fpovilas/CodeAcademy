namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short choice;
            Console.WriteLine("1. Task 3.1\n2. Task 3.2\n3. Task 3.3");

            choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Please enter number of the month: ");
                    byte month = Convert.ToByte(Console.ReadLine());

                    string season = month switch
                    {
                        12 => "winter",
                        >=1 and <= 2 => "winter",
                        > 2 and <= 5 => "spring",
                        > 5 and <= 8 => "summer",
                        > 8 and <=11 => "autumn",
                        _ => "There is only 12 months and 4 seasons"
                    };

                    Console.WriteLine($"\n{season}");
                    break;
                case 2:
                    double a, b;

                    Console.WriteLine("""
                        Addition
                        Subtraction
                        Multiplication
                        Division
                        Power
                        Root
                        """);
                    Console.Write("Please chooce mathmetical operation: ");

                    string operation = Console.ReadLine().ToLower();

                    switch (operation)
                    {
                        case "addition":
                            Console.Write("Please enter 1st componet: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter 2st componet: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"\nSum is {a + b}");
                            break;
                        case "subtraction":
                            Console.Write("Please enter contents: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter subtrahend: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"\n Diff is {a - b}");
                            break;
                        case "multiplication":
                            Console.Write("Please enter multiplicand: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter multiplier: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"\n Product is {a * b}");
                            break;
                        case "division":
                            Console.Write("Please enter dividend: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter divisor: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            if(b == 0)
                            {
                                Console.WriteLine("Division from 0 is impossible");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"\n Quotient is {a / b}");
                                break;
                            }
                        case "power":
                            Console.Write("Please enter number: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter power to the: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"\n Power is {Math.Pow(a, b)}");
                            break;
                        case "root":
                            Console.Write("Please enter underroot: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter root: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"\n Root is {Math.Pow(a, (1 / b))}");
                            break;
                        default:
                            Console.WriteLine("Wrong choice");
                            break;
                    }
                    break;
                case 3:
                    float usdToEur = 0.93487453f;
                    float usdToGbp = 0.81322426f;
                    float usdToJpy = 150.43907f;
                    float eurToUsd = 1.0695186f;
                    float eurToGbp = 0.8698093f;
                    float eurToJpy = 160.91051f;
                    float gbpToUsd = 1.2296067f;
                    float gbpToEur = 1.1496407f;
                    float gpbToJpy = 184.98584f;
                    float jpyToUsd = 0.0066471188f;
                    float jpyToEur = 0.0062152937f;
                    float jpyToGbp = 0.0054060031f;

                    float currency;
                    
                    Console.WriteLine("""
                        USD
                        EUR
                        GBP
                        JPY
                        """);
                    Console.Write("Please choose currency to convert from: ");
                    string currencyFromConvert = Console.ReadLine().ToUpper();

                    switch (currencyFromConvert)
                    {
                        case "USD":
                            Console.Write("Please enter amout of currency: ");
                            currency = Convert.ToSingle(Console.ReadLine());

                            Console.WriteLine($"\nUSD: {currency}" +
                                $"\nEUR: {currency * usdToEur}" +
                                $"\nGBP: {currency * usdToGbp}" +
                                $"\nJPY: {currency * usdToJpy}");
                            break;
                        case "EUR":
                            Console.Write("Please enter amout of currency: ");
                            currency = Convert.ToSingle(Console.ReadLine());

                            Console.WriteLine($"\nEUR: {currency}" +
                                $"\nUSD: {currency * eurToUsd}" +
                                $"\nGBP: {currency * eurToGbp}" +
                                $"\nJPY: {currency * eurToJpy}");
                            break;
                        case "GBP":
                            Console.Write("Please enter amout of currency: ");
                            currency = Convert.ToSingle(Console.ReadLine());

                            Console.WriteLine($"\nGBP: {currency}" +
                                $"\nUSD: {currency * gbpToUsd}" +
                                $"\nEUR: {currency * usdToEur}" +
                                $"\nJPY: {currency * usdToJpy}");
                            break;
                        case "JPY":
                            Console.Write("Please enter amout of currency: ");
                            currency = Convert.ToSingle(Console.ReadLine());

                            Console.WriteLine($"\nJPY: {currency}" +
                                $"\nUSD: {currency * jpyToUsd}" +
                                $"\nEUR: {currency * jpyToEur}" +
                                $"\nGBP: {currency * jpyToGbp}");
                            break;
                        default:
                            Console.WriteLine("There is no this type of currency");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("There is only 3 tasks");
                    break;
            }
        }
    }
}