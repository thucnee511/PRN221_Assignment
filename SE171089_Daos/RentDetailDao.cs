using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public class RentDetailDao : IDao<RentDetail>
    {
        private static RentDetailDao instance = null;
        private LibraryManagementContext context = null;
        private RentDetailDao()
        {
            context = new LibraryManagementContext();
        }
        public static RentDetailDao Instance
        {
            get
            {
                instance ??= new RentDetailDao();
                return instance;
            }
        }
        public List<RentDetail> GetList() => context.RentDetails.ToList();
        public RentDetail GetItem(int id) => context.RentDetails.SingleOrDefault(rentDetail => rentDetail.Id == id);
        public RentDetail Insert(RentDetail item)
        {
            context.RentDetails.Add(item);
            context.SaveChanges();
            return item;
        }
        public RentDetail Update(RentDetail item)
        {
            context.RentDetails.Update(item);
            context.SaveChanges();
            return item;
        }
        public RentDetail Delete(int id)
        {
            RentDetail item = GetItem(id);
            context.RentDetails.Remove(item);
            context.SaveChanges();
            return item;
        }
    }
}
