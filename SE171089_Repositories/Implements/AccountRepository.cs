using SE171089_BusinessObject;
using SE171089_Daos;
using SE171089_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171089_Repositories.Implements
{
    public class AccountRepository : IRepository<Account>
    {
        private IDao<Account> dao;
        public AccountRepository()
        {
            dao = new AccountDao();
        }
        public bool AddItem(Account item) => dao.AddElement(item);

        public bool DeleteItem(Account item) => dao.DeleteElement(item.Id);

        public Account GetItem(string value) => dao.GetElement(value);

        public List<Account> GetList() => dao.GetList();

        public bool UpdateItem(Account item) => dao.UpdateElement(item);
    }
}
