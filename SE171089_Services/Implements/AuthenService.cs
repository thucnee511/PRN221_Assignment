using SE171089_BusinessObject;
using SE171089_Repositories.Implements;
using SE171089_Repositories.Interfaces;
using SE171089_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.Implements
{
    public class AuthenService : IAuthenService
    {
        private readonly IRepository<Account> accountRepository;
        public AuthenService()
        {
            accountRepository = new AccountRepository();
        }
        public Account? Login(string email, string password)
        {
            Account account = accountRepository.GetItem(email);
            if (account != null && account.Password == password)
            {
                return account;
            }
            else
            {
                return null;
            }
        }
    }
}
