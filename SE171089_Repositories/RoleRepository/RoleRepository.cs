using SE171089_BusinessObject;
using SE171089_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private static RoleRepository instance;
        private RoleDao roleDao;
        private RoleRepository()
        {
            roleDao = RoleDao.Instance;
        }
        public static RoleRepository Instance
        {
            get
            {
                instance ??= new RoleRepository();
                return instance;
            }
        }
        public Role Delete(int id) => roleDao.Delete(id);
        public Role GetItem(int id) => roleDao.GetItem(id);
        public List<Role> GetList() => roleDao.GetList();
        public Role Insert(Role item) => roleDao.Insert(item);
        public Role Update(Role item) => roleDao.Update(item);
    }
}
