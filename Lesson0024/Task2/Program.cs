using Task2.Class;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Example with Book Class
                2. Example with Store Class
                """);
        }

        private static int GetChoice()
        {
            Console.WriteLine("Please enter your choice");
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                return choice;
            }
            return 0;
        }

        private static List<Book> ReturnAuthorBooks(List<Book> allBooks, string authorToFind)
        {
            List<Book> filteredBooks = new ();

            foreach(Book book in allBooks)
            {
                if(book.Author == authorToFind)
                    filteredBooks.Add(book);
            }

            return filteredBooks;
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:

                    Console.WriteLine("Class Book:");

                    Book playerGuide = new Book("The C# Player's Guide", "Whitaker RB.", 2022);
                    Console.WriteLine($"\t{playerGuide.Title} was written by {playerGuide.Author}" +
                                    $" and released in {playerGuide.ReleaseYear}");

                    Book komplekte = new("Komplekte", "Audio", 2020, "AUS");
                    Console.WriteLine($"\t{komplekte.Title} was written by {komplekte.Author}" +
                                    $" and released in {komplekte.ReleaseYear} in {komplekte.CountryCode}");

                    List<Book> allBooks = new List<Book>();
                    allBooks.Add(playerGuide);
                    allBooks.Add(komplekte);

                    List<Book> authorBook = ReturnAuthorBooks(allBooks, playerGuide.Author);

                    Console.WriteLine($"All books of {playerGuide.Author}:");
                    foreach(Book book in authorBook)
                    {
                        Console.WriteLine($"\t{book.Title}");
                    }

                    break;
                case 2:
                    Store mesine = new("Mėsine", 1997,
                        new() { "Kiauliena", "Žvėriena", "Paukštiena" });
                    mesine.PrintStoreProducts();

                    Store zoline = new("Žolinė", 2000, new() { "Kopūstai", "Agurkai", "Pomidorai" });
                    zoline.PrintStoreProducts();

                    Store uni = new("Universalioji", 2025,
                        new() { "Žvėriena", "Kalafijorai", "Baterijos", "Baklažanai"});
                    uni.PrintStoreProducts();
                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }
    }
}