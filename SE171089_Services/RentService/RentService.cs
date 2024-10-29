using SE171089_BusinessObject;
using SE171089_Repositories.RentDetailRepository;
using SE171089_Repositories.RentRepositopry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.RentService
{
    public class RentService : IRentService
    {
        private static RentService instance = null;
        private IRentRepository rentRepository = null;
        private IRentDetailRepository rentDetailRepository = null;
        private RentService()
        {
            rentRepository = RentRepository.Instance;
            rentDetailRepository = RentDetailRepository.Instance;
        }
        public static RentService Instance
        {
            get
            {
                instance ??= new RentService();
                return instance;
            }
        }

        public Rent Delete(int id)
        {
            return rentRepository.Delete(id);
        }

        public List<Rent> GetAll()
        {
            return rentRepository.GetList();
        }

        public List<Rent> GetRentByUserId(int userId)
        {
            return rentRepository.GetList().Where(x => x.UserId == userId).ToList();
        }

        public List<RentDetail> GetRentDetailByRentId(int rentId)
        {
            return rentDetailRepository.GetList().Where(x => x.RentId == rentId).ToList();
        }

        public Rent Insert(Rent rent, List<RentDetail> rentDetails)
        {
            Rent r = rentRepository.Insert(rent);
            foreach (var item in rentDetails)
            {
                item.RentId = r.Id;
                item.Book = null;
                rentDetailRepository.Insert(item);
            }
            return rentRepository.GetItem(r.Id);
        }

        public Rent Update(Rent selectedRent)
        {
            return rentRepository.Update(selectedRent);
        }
    }
}
