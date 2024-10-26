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
        public BookDao()
        {
            context = new();
        }
        public static BookDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookDao();
                }
                return instance;
            }
        }
        public List<Book> GetList() => context.Books.ToList();
        public Book GetElement(string id) => context.Books.SingleOrDefault(book => book.Id.ToString() == id);
        public bool AddElement(Book element)
        {
            bool status = false;
            try
            {
                context.Books.Add(element);
                context.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool UpdateElement(Book element)
        {
            bool status = false;
            try
            {
                Book book = GetElement(element.Id.ToString());
                if (book != null)
                {
                    context.Books.Update(element);
                    context.SaveChanges();
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool DeleteElement(int id)
        {
            bool status = false;
            try
            {
                Book book = GetElement(id.ToString());
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
