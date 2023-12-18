using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Example with Numbers Class
                2. Example with Rectanlge Class
                3. Example with Circle Class
                4. Example with Library Class
                5. Example with Library Class with Book Class
                6. Example with Playlist Class
                7. Example with Movie Class
                8. Example with Book Class
                9. Example with Computer Class
                10. Additional task with Overloading
                """);
        }

        private static void PrintMovies(int rating, List<Movie> movies)
        {
            foreach(Movie movie in movies)
            {
                if(movie.GetRating() >= rating)
                    Console.WriteLine($"{movie.GetTitle()} rating: {movie.GetRating()}");
            }
        }

        private static void PrintHowLongToReadAllBooksInList(List<Book> books)
        {
            foreach(Book book in books)
            {
                Console.WriteLine($"{book.GetAuthor()} {book.GetTitle()}" +
                            $" would take to read {book.GetReadTime():0.00}h");
            }
        }

        private static void CanIRunIt(List<Computer> computers, double ram)
        {
            foreach(Computer computer in computers)
            {
                if(computer.CanRunProgram(ram))
                    Console.WriteLine($"{computer.GetBrand()} - {computer.GetModel()} can run it");
                else
                    Console.WriteLine($"{computer.GetBrand()} - {computer.GetModel()} can't run it");
            }
        }

        private static int GetChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            { return choice; }
            else { return 0; }
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Numbers numbers = new();
                    numbers.AddNumber(1);
                    numbers.AddNumber(2);
                    numbers.AddNumber(3);

                    numbers.GetNumbers();
                    break;
                case 2:
                    Rectangle rectangle = new(5, 3);

                    Console.WriteLine($"Width: 5 and Heigh: 3");
                    rectangle.PrintPerimeter();
                    rectangle.PrintArea();
                    break;
                case 3:
                    Circle circle = new(5);

                    Console.WriteLine("Circel radius: 5 ");
                    circle.PrintPerimeter();
                    circle.PrintArea();
                    break;
                case 4:
                    Library library = new();

                    library.AddBook("Knyga 1");
                    library.AddBook("Knyga 2");
                    library.AddBook("Knyga 3");

                    library.PrintBooks();

                    Console.WriteLine();

                    library.RemoveBook("Knyga 2");

                    library.PrintBooks();
                    break;
                case 5:
                    Library libraryList = new();

                    Book book = new("Knyga 5");

                    libraryList.AddBook(book);
                    libraryList.AddBook(new Book("Knyga 6"));
                    libraryList.AddBook(new Book("Knyga 7"));

                    libraryList.PrintBooks("Book");

                    Console.WriteLine();

                    //libraryList.RemoveBook(new Book("Knyga5"));
                    libraryList.RemoveBook(book);

                    libraryList.PrintBooks("Book");

                    // Kodėl neištrina su new Book("Knyga5") patikrinti referencus
                    // Tikrina ir Adresą atmintyje
                    break;
                case 6:
                    Playlist playlist = new
                        (
                            new List<Track>
                            {
                                new Track("Daina1"),
                                new Track("Daina3"),
                                new Track("Daina2")
                            }
                        );

                    Track daina5 = new("Daina5");
                    playlist.AddTrack(daina5);
                    playlist.PrintTracks();

                    Console.WriteLine();


                    playlist.RemoveTrack(daina5);
                    playlist.PrintTracks();
                    break;
                case 7:
                    List<Movie> movies = new()
                    {
                        new Movie("Title1", "Genre1", 6),
                        new Movie("Title2", "Genre3", 4),
                        new Movie("Title3", "Genre2", 10),
                        new Movie("Title4", "Genre4", 5)
                    };

                    PrintMovies(movies: movies, rating: 5);

                    break;
                case 8:
                    List<Book> books = new()
                    {
                        new Book("Title", "Author", 23),
                        new Book("Title5", "Author1", 468),
                        new Book("Title1", "Author2", 210),
                        new Book("Title6", "Author9", 65),
                        new Book("Title4", "Author4", 1459),
                    };

                    PrintHowLongToReadAllBooksInList(books);
                    break;
                case 9:
                    List<Computer> computers = new()
                    {
                        new("Dell", "SFF", 2.5, 100),
                        new("AsRock", "AX300", 8, 512),
                        new("Gigabyte", "AT420", 4, 256)
                    };

                    CanIRunIt(computers, 4);

                    break;
                case 10:
                    FlightBooking flightBookingIdividual = new();
                    flightBookingIdividual.CreateBooking("Povilas", "0W34556X");

                    flightBookingIdividual.GetBooking("Individual");

                    FlightBooking flightBookingGroup = new();
                    flightBookingGroup.CreateBooking(new() { "Petras", "Inga" }, "0546WXA5", "Saule");

                    flightBookingGroup.GetBooking("Group");

                    //FlightBooking flightBookingCorporate = new();
                    //flightBookingCorporate.CreateBooking("Mokykla", new() { new() { "Ieva" }, "054Z48WY" });

                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            };
        }
    }
}