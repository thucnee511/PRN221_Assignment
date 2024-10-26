using SE171089_BusinessObject;
using SE171089_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private static CategoryRepository instance;
        private CategoryDao categoryDao;
        private CategoryRepository()
        {
            categoryDao = CategoryDao.Instance;
        }
        public static CategoryRepository Instance
        {
            get
            {
                instance ??= new CategoryRepository();
                return instance;
            }
        }
        public Category Delete(int id) => categoryDao.Delete(id);
        public Category GetItem(int id) => categoryDao.GetItem(id);
        public List<Category> GetList() => categoryDao.GetList();
        public Category Insert(Category item) => categoryDao.Insert(item);
        public Category Update(Category item) => categoryDao.Update(item);
    }
}
