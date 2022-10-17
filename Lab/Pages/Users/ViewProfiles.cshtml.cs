using Lab.Pages.DataClasses;
using Lab.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab.Pages.Users
{
    public class ViewProfilesModel : PageModel
    {
        [BindProperty]
        public User_Skill UserToView { get; set; }

        public List<User_Skill> SkillList { get; set; }

        public ViewProfilesModel()
        {
            UserToView = new User_Skill();
            SkillList = new List<User_Skill>();
        }
        public IActionResult OnGet(int userid)
        {
            SqlDataReader singleprofile = DBClass.SingleProfileReader(userid);
            SqlDataReader someskills = DBClass.SomeSkills(userid);
            HttpContext.Session.SetInt32("userid", userid);

            while (singleprofile.Read())
            {
                UserToView.userID = userid;
                UserToView.firstName = singleprofile["firstName"].ToString();
                UserToView.secondName = singleprofile["secondName"].ToString();
                UserToView.email = singleprofile["email"].ToString();
                UserToView.userType = singleprofile["userType"].ToString();
                UserToView.professionalCompany = singleprofile["professionalCompany"].ToString();
                UserToView.professionalEmail = singleprofile["professionalEmail"].ToString();
                UserToView.facultyAssociation = singleprofile["facultyAssociation"].ToString();
            }

            while (someskills.Read())
            {
                SkillList.Add(new User_Skill
                {

                    skill = someskills["skill"].ToString(),
                    skillLevel = someskills["skillLevel"].ToString()


                });

            }
            singleprofile.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/HashedLogin");
            }

            return Page();
        }
    }
}

