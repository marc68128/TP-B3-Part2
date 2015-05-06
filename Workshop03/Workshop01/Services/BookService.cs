using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop01.Model;

namespace Workshop01.Services
{
    public class BookService
    {
        public ICollection<Book> GetBooks()
        {
            using (var context = new BookDataContext(BookDataContext.DbConnectionString))
            {
                return context.Books.ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var context = new BookDataContext(BookDataContext.DbConnectionString))
            {
                return context.Books.FirstOrDefault(b => b.Id == id);
            }
        }

        public int AddBook(Book book)
        {
            using (var context = new BookDataContext(BookDataContext.DbConnectionString))
            {
                context.Books.InsertOnSubmit(book);
                context.SubmitChanges();
                return book.Id;
            }
        }
    }
}
