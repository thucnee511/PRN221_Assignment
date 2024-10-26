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
        public CategoryDao()
        {
            context = new();
        }
        public static CategoryDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDao();
                }
                return instance;
            }
        }
        public List<Category> GetList() => context.Categories.ToList();
        public Category GetElement(string id) => context.Categories.SingleOrDefault(category => category.Id.ToString() == id);
        public bool AddElement(Category element)
        {
            bool status = false;
            try
            {
                context.Categories.Add(element);
                context.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool UpdateElement(Category element)
        {
            bool status = false;
            try
            {
                Category category = GetElement(element.Id.ToString());
                if (category != null)
                {
                    context.Categories.Update(element);
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
                Category category = GetElement(id.ToString());
                if (category != null)
                {
                    context.Categories.Remove(category);
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
