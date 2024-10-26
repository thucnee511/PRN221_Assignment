using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public T GetItem(string value);
        public List<T> GetList();
        public bool AddItem(T item);
        public bool UpdateItem(T item);
        public bool DeleteItem(T item);
    }
}
