using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE171089_BusinessObject;
using SE171089_Services.AccountService;
using System.ComponentModel.DataAnnotations;

namespace SE171089_RazorPage.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _service;
        public LoginModel(IAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = "";
        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = "";
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Account account = _service.Login(Email, Password);
                    if (account != null)
                    {
                        if(account.RoleId == 1 || account.RoleId == 2)
                        {
                            HttpContext.Session.SetString("RoleId", account.RoleId.ToString());
                            return RedirectToPage("Index");
                        }
                        else
                        {
                            ViewData["ErrorMsg"] = "You do not have permission to access this page.";
                        }
                    }
                    else
                    {
                        ViewData["ErrorMsg"] = "Invalid username or password.";
                    }
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMsg"] = ex.Message;
                }
            }
            return Page();
        }
    }
}
