using SE171089_BusinessObject;
using SE171089_Repositories.BookRepository;
using SE171089_Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.BookService
{
    public class BookService : IBookService
    {
        private static BookService _instance;
        private IBookRepository _bookRepository;
        private ICategoryRepository _categoryRepository;
        private BookService()
        {
            _bookRepository = BookRepository.Instance;
            _categoryRepository = CategoryRepository.Instance;
        }
        public static BookService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookService();
                }
                return _instance;
            }
        }

        public Book AddBook(Book book)
        {
            return _bookRepository.Insert(book);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetList();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetList();
        }
    }
}
