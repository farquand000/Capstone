using Lab.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.Pages.Login
{
    public class CreateHashedLoginModel : PageModel
    {

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string passphrase { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Perform Validation First on Form
            // then...

            DBClass.CreateHashedUser(username, passphrase);

            // Perform actual logic to check if user was successfully
            //  added in your projects but for demo purposes we can say:

            ViewData["UserCreate"] = "User Successfully Created!";

            return RedirectToPage("HashedLogin");
        }
    }
}
