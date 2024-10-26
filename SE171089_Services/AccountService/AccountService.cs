using SE171089_BusinessObject;
using SE171089_Repositories.AccountRepository;
using SE171089_Repositories.RoleRepository;
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
        private IRoleRepository _roleRepository;
        private AccountService()
        {
            _accountRepository = AccountRepository.Instance;
            _roleRepository = RoleRepository.Instance;
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

        public Account GetByEmail(string email)
        {
            return _accountRepository.GetByEmail(email);
        }

        public Account GetByUsername(string username)
        {
            return _accountRepository.GetByUsername(username);
        }

        public string GetRoleName(int roleId)
        {
            Role role = _roleRepository.GetItem(roleId);
            return role.Name;
        }

        public Account Insert(Account account)
        {
            return _accountRepository.Insert(account);
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

        public List<Account> Search(string keyword)
        {
            List<Account> accounts = _accountRepository.GetList();
            return accounts.Where(a => a.Username.Contains(keyword) || a.Email.Contains(keyword)).ToList();
        }
    }
}
