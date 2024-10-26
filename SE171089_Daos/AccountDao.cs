using SE171089_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Daos
{
    public class AccountDao : IDao<Account>
    {
        private static AccountDao instance = null;
        private LibraryManagementContext context = null;
        public AccountDao()
        {
            context = new();
        }
        public static AccountDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDao();
                }
                return instance;
            }
        }
        public List<Account> GetList() => context.Accounts.ToList();
        public Account GetElement(string value)
            => context.Accounts.SingleOrDefault(account => account.Id.ToString().Equals(value)
            || account.Username.Equals(value)
            || account.Email.Equals(value));
        public bool AddElement(Account element)
        {
            bool status = false;
            try
            {
                context.Accounts.Add(element);
                context.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool UpdateElement(Account element)
        {
            bool status = false;
            try
            {
                Account account = GetElement(element.Id.ToString());
                if (account != null)
                {
                    context.Accounts.Update(element);
                    context.SaveChanges();
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool DeleteElement(int id)
        {
            bool status = false;
            try
            {
                Account account = GetElement(id.ToString());
                if (account != null)
                {
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
