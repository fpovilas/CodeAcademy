using MongoDB.Bson;
using MongoDB.Model;
using MongoDB.Repository;
using MongoDB.Repository.Interface;

namespace MongoDB
{
    internal class Program
    {
        static void Main()
        {

            IBookRepository bookRepository = new BookRepository();
            IPageRepository pageRepository = new PageRepository();

            #region BookObjects

            
            Book bookTarzan = new()
            {
                Name = "Tarzan"
            };

            Book bookHunter = new()
            {
                Name = "Hunter"
            };

            
            List<Page> pages = [];
            for (int i = 0; i < 100; i++)
            {
                Page page = new()
                {
                    ID = ObjectId.GenerateNewId().ToString(),
                    Content = $"Content - {i}"
                };
                pages.Add(page);
            }

            Book bookWithPages = new()
            {
                Name = "Book With Pages",
                Pages = pages
            };

            Book bookNewTarzan = new()
            {
                ID = bookRepository.GetFirstBookByName("NewTarzan").ID,
                Name = "NewTarzan"
            };

            bookRepository.CreateBook(bookTarzan);
            bookRepository.CreateBook(bookHunter);
            bookRepository.CreateBook(bookWithPages);
            bookRepository.DeleteBook(bookRepository.GetFirstBookByName(bookTarzan.Name).ID);
            bookRepository.DeleteBook("65d79759604406fa2352ef02");
            bookRepository.DeleteBook("65d796db414f5b1ee19acd8b");
            bookRepository.DeleteBook("65d79687ab182b6e40006453");
            bookRepository.UpdateBook(bookNewTarzan.ID!, bookNewTarzan);

            #endregion

            #region PageObjects

            Page page = new()
            {
                Content = "Page content"
            };
            pageRepository.CreatePage(page);

            Page pageToDelete = new()
            {
                Content = "Content to be deleted",
                ID = ObjectId.GenerateNewId().ToString()
            };

            pageRepository.CreatePage(pageToDelete);
            pageRepository.DeletePage(pageToDelete.ID);

            Page pageToUpdate = new()
            {
                ID = pageRepository.GetPageByID("65d7a03e6f685d513f328c61").ID!,
                Content = "New Content"
            };

            pageRepository.UpdatePage(pageToUpdate.ID, pageToUpdate);

            #endregion
        }
    }
}