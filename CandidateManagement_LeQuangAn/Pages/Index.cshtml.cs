using CandidateManagement_LeQuangAn.Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_LeQuangAn.Pages;

public class IndexModel : PageModel
{
    private IHRAccountRepo hRAcountRepo;

    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Msg { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        hRAcountRepo = new HRAccountRepo();
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        var user = hRAcountRepo.GetUserHraccounts().FirstOrDefault(u => u.Email.Equals(Email) && u.Password.Equals(Password));
        if (user != null)
        {
            if (user.MemberRole == 2)
            {
                HttpContext.Session.SetString("email", Email);
                //return RedirectToPage("/TemplateHrAccount/Index");
                return RedirectToPage("/CandidateCRUD/Index");
            }
            else
            {
                Msg = "You are not allowed to do this function!";
                return Page();
            }
        }
        else
        {
            Msg = "You must type data in form";
            return Page();
        }
    }
}