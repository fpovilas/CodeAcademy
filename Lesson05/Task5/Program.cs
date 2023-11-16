namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Country codes
            const string codeLT = "370";
            const string codeEE = "372";
            const string codeLV = "371";
            const string codeDK = "45";
            const string codeUK = "44";
            const string codeNO = "47";
            const string codeFI = "358";
            const string codeSE = "46";
            const string codeAL = "355";
            const string codeMD = "373";
            const string codeUSA = "1";
            #endregion

            #region Price per minute
            const double priceLT = 0;
            const double priceEE = 0.2299;
            const double priceLV = 0.2299;
            const double priceDK = 0.2299;
            const double priceUK = 0.2299;
            const double priceNO = 0.2299;
            const double priceFI = 0.2299;
            const double priceSE = 0.2299;
            const double priceAL = 1.1495;
            const double priceMD = 0.9680;
            const double priceUSA = 0.7260;
            #endregion

            #region Other needed variables
            string phoneNumber;
            double callTime = 0, finalCallPrice = 0, callPrice = 0;
            bool isDone = false;
            #endregion

            // Asking for phone number
            Console.Write("Call to number (Country Code + 8 Integers): ");
            phoneNumber = Console.ReadLine();

            // Checking if phone numbers length is between 9 and 11
            if(phoneNumber.Length <= 11 && phoneNumber.Length >= 9)
            {
                // Getting how long will call take
                Console.Write("Call time in minutes: ");
                callTime = Convert.ToDouble(Console.ReadLine());

                // Checking if time is not 0
                if(callTime != 0)
                {
                    switch (phoneNumber.Length)
                    {
                        case 11:
                        switch (phoneNumber.Substring(0, 3))
                        {
                            case codeLT:
                                    finalCallPrice = callTime * priceLT;
                                    callPrice = priceLT;
                                    isDone = true;
                                    break;
                            case codeEE:
                                    finalCallPrice = callTime * priceEE;
                                    callPrice = priceEE;
                                    isDone = true;
                                    break;
                            case codeLV:
                                    finalCallPrice = callTime * priceLV;
                                    callPrice = priceLV;
                                    isDone = true;
                                    break;
                            case codeFI:
                                    finalCallPrice = callTime * priceFI;
                                    callPrice = priceFI;
                                    isDone = true;
                                    break;
                            case codeAL:
                                    finalCallPrice = callTime * priceAL;
                                    callPrice = priceAL;
                                    isDone = true;
                                    break;
                            case codeMD:
                                    finalCallPrice = callTime * priceMD;
                                    callPrice = priceMD;
                                    isDone = true;
                                    break;
                                default:
                                    break;
                        }
                        break;
                        case 10:
                            switch (phoneNumber.Substring(0, 2))
                            {
                                case codeDK:
                                    finalCallPrice = callTime * priceDK;
                                    callPrice = priceDK;
                                    isDone = true;
                                    break;
                                case codeUK:
                                    finalCallPrice = callTime * priceUK;
                                    callPrice = priceUK;
                                    isDone = true;
                                    break;
                                case codeNO:
                                    finalCallPrice = callTime * priceNO;
                                    callPrice = priceNO;
                                    isDone = true;
                                    break;
                                case codeSE:
                                    finalCallPrice = callTime * priceSE;
                                    callPrice = priceSE;
                                    isDone = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 9:
                            switch (phoneNumber.Substring(0,1))
                            {
                                case codeUSA:
                                    finalCallPrice = callTime * priceUSA;
                                    callPrice = priceUSA;
                                    isDone = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Somthing went wrong");
                            break;
                    }
                }
                else { Console.WriteLine("You entered wrong time. Please enter time with ',' character"); }
            }
            else { Console.WriteLine("You entered wrong number"); }

            if(isDone)
            {
                Console.WriteLine("\nOperator: Telia\n");
                Console.WriteLine($"Call to number: +{phoneNumber}\n" +
                                  $"Call time: {callTime}\n" +
                                  $"Call price: {callPrice}\\min\n" +
                                  $"Final call price: {finalCallPrice:#.##}");
            }
            else { Console.WriteLine("Somthing went wrong"); }
        }
    }
}