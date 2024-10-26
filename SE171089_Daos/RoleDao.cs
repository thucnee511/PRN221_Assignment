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
        public RoleDao()
        {
            context = new();
        }
        public static RoleDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleDao();
                }
                return instance;
            }
        }
        public List<Role> GetList() => context.Roles.ToList();
        public Role GetElement(string id) => context.Roles.SingleOrDefault(role => role.Id.ToString() == id);
        public bool AddElement(Role element)
        {
            bool status = false;
            try
            {
                context.Roles.Add(element);
                context.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool UpdateElement(Role element)
        {
            bool status = false;
            try
            {
                Role role = GetElement(element.Id.ToString());
                if (role != null)
                {
                    context.Roles.Update(element);
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
                Role role = GetElement(id.ToString());
                if (role != null)
                {
                    context.Roles.Remove(role);
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
