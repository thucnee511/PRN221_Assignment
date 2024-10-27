using SE171089_BusinessObject;
using SE171089_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.RentRepositopry
{
    public class RentRepository : IRentRepository
    {
        private static RentRepository instance;
        private RentDao rentDao;
        private RentRepository()
        {
            rentDao = RentDao.Instance;
        }
        public static RentRepository Instance
        {
            get
            {
                instance ??= new RentRepository();
                return instance;
            }
        }
        public Rent Delete(int id) => rentDao.Delete(id);
        public Rent GetItem(int id) => rentDao.GetItem(id);
        public List<Rent> GetList() => rentDao.GetList();

        public List<Rent> GetListByUserId(int userId)
        {
            return rentDao.GetList().Where(rent => rent.UserId == userId).ToList();
        }
        public Rent Insert(Rent item) => rentDao.Insert(item);
        public Rent Update(Rent item) => rentDao.Update(item);
    }
}
