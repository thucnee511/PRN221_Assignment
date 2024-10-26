using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public class BookDao : IDao<Book>
    {
        private static BookDao instance = null;
        private LibraryManagementContext context = null;
        private BookDao()
        {
            context = new LibraryManagementContext();
        }
        public static BookDao Instance
        {
            get
            {
                instance ??= new BookDao();
                return instance;
            }
        }
        public List<Book> GetList() => context.Books.ToList();
        public Book GetItem(int id) => context.Books.SingleOrDefault(book => book.Id == id);
        public Book Insert(Book item)
        {
            context.Books.Add(item);
            context.SaveChanges();
            return item;
        }
        public Book Update(Book item)
        {
            context.Books.Update(item);
            context.SaveChanges();
            return item;
        }
        public Book Delete(int id)
        {
            Book item = GetItem(id);
            context.Books.Remove(item);
            context.SaveChanges();
            return item;
        }
    }
}
