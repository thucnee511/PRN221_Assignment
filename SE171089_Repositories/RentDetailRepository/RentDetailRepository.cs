using SE171089_BusinessObject;
using SE171089_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.RentDetailRepository
{
    public class RentDetailRepository : IRentDetailRepository
    {
        private static RentDetailRepository instance = null;
        private RentDetailDao rentDetailDao = null;
        private RentDetailRepository()
        {
            rentDetailDao = RentDetailDao.Instance;
        }
        public static RentDetailRepository Instance
        {
            get
            {
                instance ??= new RentDetailRepository();
                return instance;
            }
        }
        public RentDetail Delete(int id) => rentDetailDao.Delete(id);
        public RentDetail GetItem(int id) => rentDetailDao.GetItem(id);
        public List<RentDetail> GetList()
        {
            return rentDetailDao.GetList();
        }
        public List<RentDetail> GetRentDetails(int rentId) 
            => rentDetailDao.GetList().Where(x => x.RentId == rentId).ToList();
        public RentDetail Insert(RentDetail item) => rentDetailDao.Insert(item);
        public RentDetail Update(RentDetail item)
        {
            throw new NotImplementedException();
        }
    }
}
