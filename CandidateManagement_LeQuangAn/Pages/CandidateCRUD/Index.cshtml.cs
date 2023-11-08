using CandidateManagement_LeQuangAn.Repo.DataAccess;
using CandidateManagement_LeQuangAn.Repo.Models;
using CandidateManagement_LeQuangAn.Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_LeQuangAn.Pages.CandidateCRUD;

public class IndexModel : PageModel
{
    private ICandidateProfileRepo candidateProfileRepo;
    public string Email { get; set; }

    // private readonly ICandidateService _candidateService;
    private CandidateProfileContext candidateProfileContext = new CandidateProfileContext();

    private CandidateManagementContext candidateManagementContext = new CandidateManagementContext();

    private readonly ILogger<IndexModel> _logger;

    public IndexModel()
    {
        //_logger = logger;
        candidateProfileRepo = new CandidateProfileRepo();
        // candidateProfileContext = new CandidateProfileContext();
        //  candidateManagementContext = _db;
        // _candidateService = candidateService;
    }

    [BindProperty]
    public string fullName { get; set; }

    [BindProperty]
    public DateTime birthDay { get; set; }

    [BindProperty]
    public string Msg { get; set; }

    [BindProperty]
    public List<CandidateProfile> CandidateProfile { get; set; }

    public int totalCandidate { get; set; }

    public int pageNo { get; set; }

    public int pageSize { get; set; }

    public void OnGet(int p = 1, int s = 3)
    {
        Email = HttpContext.Session.GetString("email");
        if (HttpContext.Session.GetString("email") == null)
        {
            Response.Redirect("/Login");
        }

        //CandidateProfile = candidateManagementContext.CandidateProfiles.Skip((p -1) * s).Take(s).ToList();
        CandidateProfile = candidateProfileContext.getCanidatePages(p, s);
        pageSize = s;
        totalCandidate = candidateProfileContext.getTotalCandidatePages();
        //totalCandidate = candidateManagementContext.CandidateProfiles.Count();
        pageNo = p;
    }

    public IActionResult OnPostSearch()
    {
        string search = Request.Form["txtSearch"];
        string type = Request.Form["type"];
        if (search != null && type.Equals("1"))
        {
            CandidateProfile = candidateProfileRepo.searchByFullName(search);
            return Page();
        }
        else if (search != null && type.Equals("2"))
        {
            CandidateProfile = candidateProfileRepo.searchByBirthDay(search);
            return Page();
        }
        CandidateProfile = candidateProfileRepo.GetCandidateProfiles();
        return Page();
    }

    public IActionResult OnGetLogout()
    {
        HttpContext.Session.Remove("email");
        return RedirectToPage("/CandidateCRUD/Index");
    }
}