using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public class CategoryDao : IDao<Category>
    {
        private static CategoryDao instance = null;
        private LibraryManagementContext context = null;
        private CategoryDao()
        {
            context = new LibraryManagementContext();
        }
        public static CategoryDao Instance
        {
            get
            {
                instance ??= new CategoryDao();
                return instance;
            }
        }
        public List<Category> GetList() => context.Categories.ToList();
        public Category GetItem(int id) => context.Categories.SingleOrDefault(category => category.Id == id);
        public Category Insert(Category item)
        {
            context.Categories.Add(item);
            context.SaveChanges();
            return item;
        }
        public Category Update(Category item)
        {
            context.Categories.Update(item);
            context.SaveChanges();
            return item;
        }
        public Category Delete(int id)
        {
            Category item = GetItem(id);
            context.Categories.Remove(item);
            context.SaveChanges();
            return item;
        }
    }
}
