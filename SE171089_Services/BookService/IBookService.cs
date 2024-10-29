using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.BookService
{
    public interface IBookService
    {
        Book AddBook(Book book);
        Book GetBookById(int id);
        List<Book> GetBooks();
        List<Category> GetCategories();
        Book Remove(Book selectedBook);
        List<Book> Search(string keyword, int cateId);
        Book Update(Book selectedBook);
    }
}
