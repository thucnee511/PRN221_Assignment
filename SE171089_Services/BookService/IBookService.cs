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
        List<Book> GetBooks();
        List<Category> GetCategories();
        List<Book> Search(string keyword, int cateId);
    }
}
