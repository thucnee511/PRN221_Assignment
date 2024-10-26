using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public interface IDao<T>
    {
        List<T> GetList();
        T GetElement(string id);
        bool AddElement(T element);
        bool UpdateElement(T element);
        bool DeleteElement(int id);
    }
}
