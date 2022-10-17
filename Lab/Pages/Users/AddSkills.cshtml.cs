using Lab.Pages.DataClasses;
using Lab.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EmptyCoreAppTest.Pages.Users
{
    public class AddSkillsModel : PageModel
    {

        [BindProperty]
        [Required]
        public UserSkill NewSkill { get; set; }

        [BindProperty]
        public int userID { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/HashedLogin");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            NewSkill.userID = (int)HttpContext.Session.GetInt32("userid");
            DBClass.InsertSkill(NewSkill);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostPopulateHandler()
        {

            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                NewSkill.skill = "Python";
                NewSkill.skillLevel = "Intermediate";

            }

            return Page();
        }
        public IActionResult OnPostClearHandler()
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                NewSkill.skill = "";
                NewSkill.skillLevel = "";
            }
            return Page();

        }
    }
}
