using SE171089_BusinessObject;
using SE171089_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private static BookRepository instance = null;
        private BookDao bookDao = null;
        private BookRepository() {
            bookDao = BookDao.Instance;
        }
        public static BookRepository Instance
        {
            get
            {
                instance ??= new BookRepository();
                return instance;
            }
        }
        public Book Delete(int id) => bookDao.Delete(id);
        public Book GetItem(int id) => bookDao.GetItem(id);
        public List<Book> GetList() => bookDao.GetList();
        public Book Insert(Book item) => bookDao.Insert(item);
        public Book Update(Book item) => bookDao.Update(item);
    }
}
