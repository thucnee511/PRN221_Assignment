using Microsoft.EntityFrameworkCore;
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
        private AccountDao()
        {
            context = new LibraryManagementContext();
        }
        public static AccountDao Instance
        {
            get
            {
                instance ??= new AccountDao();
                return instance;
            }
        }
        public List<Account> GetList() => context.Accounts.Include(a => a.Role).ToList();
        public Account GetItem(int id) => context.Accounts.Include(a => a.Role).SingleOrDefault(account => account.Id == id);
        public Account Insert(Account item)
        {
            context.Accounts.Add(item);
            context.SaveChanges();
            return item;
        }
        public Account Update(Account item)
        {
            context.Accounts.Update(item);
            context.SaveChanges();
            return item;
        }
        public Account Delete(int id)
        {
            Account item = GetItem(id);
            item.Status = 0;
            context.Accounts.Update(item);
            context.SaveChanges();
            return item;
        }
    }
}
