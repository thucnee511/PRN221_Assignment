using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE171089_BusinessObject;
using SE171089_Daos;
using SE171089_Services.AccountService;

namespace SE171089_RazorPage.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _service;

        public CreateModel(IAccountService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Account == null)
            {
                return Page();
            }
            _service.Insert(Account);
            return RedirectToPage("./Index");
        }
    }
}
