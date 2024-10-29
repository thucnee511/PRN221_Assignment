using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE171089_BusinessObject;
using SE171089_Daos;
using SE171089_Services.AccountService;

namespace SE171089_RazorPage.Pages.AccountPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _service;

        public IndexModel(IAccountService service)
        {
            _service = service;
        }

        public IList<Account> Account { get;set; } = default!;

        public void OnGet()
        {
            if (_service.GetAccounts() != null)
            {
                Account = _service.GetActiveAccounts();
            }
        }
    }
}
