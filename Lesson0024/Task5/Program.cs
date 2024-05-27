using Task5.Class;

namespace Task5
{
    internal class Program
    {
        static void Main()
        {
            bool payForCart = false;

            PrintHello();
            string name = GetName();

            User user = new(name);
            List<Product> storeProducts = PopulateStoreWithProducts();

            Console.Clear();
            Console.WriteLine($"Hello, {user.Name}");
            do
            {
                Console.Clear();
                PrintCategories(storeProducts);
                Console.Write("Please choose category: ");

                int productCategory = GetChoice();
                
                if(productCategory == 0)
                    Console.WriteLine("Wrong choice...");
                else
                {
                    Product product;

                    switch (productCategory)
                    {
                        case 1:
                            PrintProductsInCategory(storeProducts, "Fruit");
                            Console.Write("Please choose one product: ");
                            product = GetProduct(storeProducts, "Fruit", GetChoice());
                            AddToCart(ref user, product);
                            break;
                        case 2:
                            PrintProductsInCategory(storeProducts, "Meat");
                            Console.Write("Please choose one product: ");
                            product = GetProduct(storeProducts, "Meat", GetChoice());
                            AddToCart(ref user, product);
                            break;
                        case 3:
                            PrintProductsInCategory(storeProducts, "Vegetable");
                            Console.Write("Please choose one product: ");
                            product = GetProduct(storeProducts, "Vegetable", GetChoice());
                            AddToCart(ref user, product);
                            break;
                        default:
                            PrintProductsInCategory(storeProducts);
                            Console.Write("Please choose one product: ");
                            product = GetProduct(storeProducts, "All", GetChoice());
                            AddToCart(ref user, product);
                            break;
                    }

                    Console.WriteLine("Do you want to pay for groceries(y/n): ");
                    payForCart = ((Console.ReadLine() ?? "n").ToLower() == "y");
                }
            } while (!payForCart);

            PrintReceipt(user);
        }

        private static int GetChoice()
        {
            if(int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else { return 0; }
        }

        private static string GetName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine() ?? "";
            return name;
        }

        private static Product GetProduct(List<Product> storeProducts, string category, int choice)
        {
            List<Product> productsByCategory = GetProductsByCategory(storeProducts, category);

            return new Product(productsByCategory[choice - 1].Name,
                        productsByCategory[choice - 1].Description,
                        productsByCategory[choice - 1].Price,
                        productsByCategory[choice - 1].Category);
        }

        private static List<Product> GetProductsByCategory(List<Product> storeProducts, string category)
        {
            List<Product > products = new ();

            if (category == "All")
            {
                foreach (Product product in storeProducts)
                {
                    products.Add(product);
                }
            }
            else
            {
                foreach (Product product in storeProducts)
                {
                    if (product.Category == category)
                        products.Add(product);
                }
            }

            return products;
        }

        private static void AddToCart(ref User user, Product product)
        {
            user.AddProduct(product);
        }

        private static void PrintCategories(List<Product> storeProducts)
        {
            int counter = 1;
            List<string> categoryFilter = new();
            foreach (Product product in storeProducts)
            {
                if(!categoryFilter.Contains(product.Category))
                {
                    categoryFilter.Add(product.Category);
                    Console.WriteLine($"{counter}. {product.Category}");
                    counter++;
                }
            }
            Console.WriteLine($"{counter}. View all products");
        }

        private static void PrintProductsInCategory(List<Product> storeProducts, string category = "All")
        {
            Console.Clear();

            int counter = 1;
            foreach(Product product in storeProducts)
            {
                if(category == "All")
                {
                    Console.Write($"{counter}. ");
                    PrintColorMagentaText(product.Description);
                    Console.Write(" ");
                    PrintColorMagentaText(product.Name);
                    Console.Write(" - ");
                    PrintColorGreenText(product.Price.ToString());
                    Console.WriteLine(" Eur");
                    counter++;
                }
                if(product.Category == category)
                {
                    Console.Write($"{counter}. ");
                    PrintColorMagentaText(product.Description);
                    Console.Write(" ");
                    PrintColorMagentaText(product.Name);
                    Console.Write(" - ");
                    PrintColorGreenText(product.Price.ToString());
                    Console.WriteLine(" Eur");
                    counter++;
                }
            }
        }

        private static void PrintHello()
        {
            Console.WriteLine("Welcome to store");
        }

        private static void PrintReceipt(User user)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            double total = 0;
            Console.WriteLine($"* ---- {user.Name, -10} Receipt ---- *");
            foreach(Product product in user.ShoppingCart)
            {
                Console.WriteLine($"* {(product.Description + " " + product.Name), -15}" +
                    $" {product.Price, 8} Eur *");
                total += product.Price;
            }
            Console.WriteLine("*------------------------------*");
            Console.WriteLine($"* Your Total: {total, 12:#.##} Eur *");
            Console.WriteLine("********************************");
            Console.ResetColor();
        }

        private static void PrintColorGreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor ();
        }

        private static void PrintColorMagentaText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(text);
            Console.ResetColor();
        }

        private static List<Product> PopulateStoreWithProducts()
        {
            List<Product> products = new ()
            {
                new Product("Apple", "Green", 0.49, "Fruit"),
                new Product("Apple", "Red", 0.59, "Fruit"),
                new Product("Grapes", "Seedles", 1.49, "Fruit"),
                new Product("Poultre", "Raw", 2.49, "Meat"),
                new Product("Veal", "Unfrozen", 5.49, "Meat"),
                new Product("Pork", "Unfrozen", 3.49, "Meat"),
                new Product("Tomato", "Cherry", 1.69, "Vegetable"),
                new Product("Carrot", "Baby", 0.99, "Vegetable"),
                new Product("Lettice", "Iceberg", 0.79, "Vegetable"),
            };

            return products;
        }
    }
}