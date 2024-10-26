using SE171089_BusinessObject;
using SE171089_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private static AccountRepository instance = null;
        private AccountDao accountDao = null;
        private AccountRepository()
        {
            accountDao = AccountDao.Instance;
        }
        public static AccountRepository Instance
        {
            get
            {
                instance ??= new AccountRepository();
                return instance;
            }
        }
        public List<Account> GetList() => accountDao.GetList();
        public Account GetItem(int id) => accountDao.GetItem(id);
        public Account GetByEmail(string email) => accountDao.GetList().SingleOrDefault(account => account.Email.Equals(email));    
        public Account GetByUsername(string username) => accountDao.GetList().SingleOrDefault(account => account.Username.Equals(username));
        public Account Insert(Account item) => accountDao.Insert(item);

        public Account Update(Account item) => accountDao.Update(item);
        public Account Delete(int id) => accountDao.Delete(id);
    }
}
