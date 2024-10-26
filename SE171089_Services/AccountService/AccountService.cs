using SE171089_BusinessObject;
using SE171089_Repositories.AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Services.AccountService
{
    public class AccountService : IAccountService
    {
        private static AccountService instance;
        private IAccountRepository _accountRepository;
        private AccountService()
        {
            _accountRepository = AccountRepository.Instance;
        }
        public static AccountService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountService();
                }
                return instance;
            }
        }

        public List<Account> GetAccounts()
        {
            return _accountRepository.GetList();
        }

        public Account Login(string email, string password)
        {
            Account account = _accountRepository.GetByEmail(email);
            if (account != null)
            {
                if (account.Password == password)
                {
                    return account;
                }
                else
                {
                    throw new Exception("Email or password is incorrect!!!");
                }
            }
            throw new Exception("Wrong login credentials!!!");
        }
    }
}
