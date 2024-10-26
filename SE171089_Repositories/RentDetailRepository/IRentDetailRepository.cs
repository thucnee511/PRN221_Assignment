using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.RentDetailRepository
{
    public interface IRentDetailRepository : IRepository<RentDetail>
    {
        List<RentDetail> GetRentDetails(int rentId);
    }
}
