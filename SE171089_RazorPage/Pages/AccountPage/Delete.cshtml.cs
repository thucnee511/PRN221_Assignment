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
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _service;

        public DeleteModel(IAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null || _service.GetAccounts().Count <= 0)
            {
                return NotFound();
            }

            Account account = _service.GetAccount(id.Value);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _service.GetAccounts().Count <= 0)
            {
                return NotFound();
            }
            Account account = _service.GetAccount(id.Value);

            if (account != null)
            {
                Account = account;
                _service.Delete(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
