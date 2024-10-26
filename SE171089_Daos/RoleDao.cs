using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public class RoleDao : IDao<Role>
    {
        private static RoleDao instance = null;
        private LibraryManagementContext context = null;
        private RoleDao()
        {
            context = new LibraryManagementContext();
        }
        public static RoleDao Instance
        {
            get
            {
                instance ??= new RoleDao();
                return instance;
            }
        }
        public List<Role> GetList() => context.Roles.ToList();
        public Role GetItem(int id) => context.Roles.SingleOrDefault(role => role.Id == id);
        public Role Insert(Role item)
        {
            context.Roles.Add(item);
            context.SaveChanges();
            return item;
        }
        public Role Update(Role item)
        {
            context.Roles.Update(item);
            context.SaveChanges();
            return item;
        }
        public Role Delete(int id)
        {
            Role item = GetItem(id);
            context.Roles.Remove(item);
            context.SaveChanges();
            return item;
        }
    }
}
