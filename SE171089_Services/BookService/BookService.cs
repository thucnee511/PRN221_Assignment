using SE171089_BusinessObject;
using SE171089_Repositories.BookRepository;
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
        private BookService()
        {
            _bookRepository = BookRepository.Instance;
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
        
        public List<Book> GetBooks()
        {
            return _bookRepository.GetList();
        }
    }
}
