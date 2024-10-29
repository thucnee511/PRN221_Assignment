using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.RentService
{
    public interface IRentService
    {
        Rent Delete(int id);
        public List<Rent> GetAll();
        public List<Rent> GetRentByUserId(int userId);
        public List<RentDetail> GetRentDetailByRentId(int rentId);
        Rent Insert(Rent rent, List<RentDetail> rentDetails);
        Rent Update(Rent selectedRent);
    }
}
