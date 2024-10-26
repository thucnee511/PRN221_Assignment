using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public interface IDao<T> where T : class
    {
        List<T> GetList();
        T GetItem(int id);
        T Insert(T item);
        T Update(T item);
        T Delete(int id);
    }
}
