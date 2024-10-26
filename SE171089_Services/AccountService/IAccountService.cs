using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.AccountService
{
    public interface IAccountService
    {
        Account Login(string email, string password);
        List<Account> GetAccounts();
        string GetRoleName(int roleId);
        List<Account> Search(string keyword);
        Account GetByUsername(string username);
        Account GetByEmail(string email);
        Account Insert(Account account);
    }
}
