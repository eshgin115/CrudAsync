using DemoApplication.Database.Models;

namespace DemoApplication.Areas.Client.ViewModels.Book
{
    public class ModelViewModel
    {
        public ModelViewModel(string title, Author author, decimal price, int authorId)
        {
            Title = title;
            Author = author;
            Price = price;
            AuthorId = authorId;
        }

        public string Title { get; set; }
        public decimal Price { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }


    }
}
