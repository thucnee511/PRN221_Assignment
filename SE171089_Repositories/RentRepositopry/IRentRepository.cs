using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.RentRepositopry
{
    public interface IRentRepository : IRepository<Rent>
    {
        List<Rent> GetListByUserId(int userId);
    }
}
