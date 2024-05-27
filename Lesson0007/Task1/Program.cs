namespace Task1 {     internal class Program     {         static void Main(string[] args)         {             #region Variables              string choice;             int index, j, number;              #endregion              Console.WriteLine("1.1.1 While loop from 1 to 5\n" +
                            "1.1.2 While loop from 5 to 1\n" +                             "1.2.1 Even number loop\n" +
                            "1.2.2 Odd number loop\n" +                             "1.3.1 Number 100 stops loop\n" +
                            "1.3.2 Negative number stops loop");              Console.Write("Choose the task: ");             choice = Console.ReadLine();              switch (choice)             {                 case "1.1":
                    #region My Initial Solution                     //index = j = 1;
                                                                    //while (index <= 5)
                                                                    //{
                                                                    //    Console.WriteLine($"1st while loop index: {index}");
                                                                    //    while (j <= 5)
                                                                    //    {
                                                                    //        Console.WriteLine($"\t2nd while loop index: {j}");
                                                                    //        j++;
                                                                    //    }
                                                                    //    index++;
                                                                    //    j = 1;
                                                                    //}
                    #endregion                     
                    // Remade as it sould be
                    index = 1;                     while (index <= 5)                         Console.Write($"{index} ");                     break;                 case "1.2":                     index = 5;                     while (index >= 1)                         Console.Write($"{index} ");                     break;                 case "2.1":
                    #region My Initial Solution                     //index = j = 1;                     //while (index <= 10)                     //{                     //    if (index % 2 == 0)                     //        Console.Write($"{index}\n");                      //    while (j <= 10)                     //    {                     //        if (j == 1)                     //            Console.Write("\t");                      //        if (j % 2 != 0)                     //            Console.Write($"{j} ");                     //        j++;                     //    }                     //    Console.Write("\n");                      //    index++;                     //    j = 1;                     //}
                    #endregion 
                    // Remade as it should be
                    index = 1;                     while(index <= 10)
                    {
                        if (index % 2 == 0)
                            Console.Write($"{index} ");
                    }                     break;                 case "2.2":                     index = 1;                     while (index <= 10)
                    {
                        if (index % 2 != 0)
                            Console.Write($"{index} ");
                    }                     break;                 case "3.1":
                    #region My Initial Solution                     //Console.Write("Please enter the number: ");                     //number = Convert.ToInt32(Console.ReadLine());                     //while (number != 100)                     //{                     //    index = 1;                      //    while (index > 0)                     //    {                     //        Console.Write("Please enter the number: ");                     //        index = Convert.ToInt32(Console.ReadLine());                     //    }                      //    Console.Write("Please enter the number: ");                     //    number = Convert.ToInt32(Console.ReadLine());                     //}                     //Console.WriteLine("You entered 100.");                     #endregion                                          // Remade as it should be                     Console.Write("Please enter the number: ");                     number = Convert.ToInt32(Console.ReadLine());                      while (number < 100)
                    {
                        Console.Write("Please enter the number: ");
                        number = Convert.ToInt32(Console.ReadLine());
                    }                      Console.WriteLine("Out of While loop!");                     break;                 case "3.2":                     Console.Write("Please enter the number: ");                     number = Convert.ToInt32(Console.ReadLine());                      while (number > 0)
                    {
                        Console.Write("Please enter the number: ");
                        number = Convert.ToInt32(Console.ReadLine());
                    }                      Console.WriteLine("Out of While loop!");                     break;                 default:                     Console.WriteLine("There is only 6 tasks");                     break;             }         }     } }