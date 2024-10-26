using SE171089_BusinessObject;
using SE171089_Daos;
using SE171089_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.Implements
{
    public class BookRepository : IRepository<Book>
    {
        private IDao<Book> dao;
        public bool AddItem(Book item) => dao.AddElement(item);

        public bool DeleteItem(Book item) => dao.DeleteElement(item.Id);

        public Book GetItem(string value) => dao.GetElement(value);

        public List<Book> GetList() => dao.GetList();

        public bool UpdateItem(Book item) => dao.UpdateElement(item);
    }
}
