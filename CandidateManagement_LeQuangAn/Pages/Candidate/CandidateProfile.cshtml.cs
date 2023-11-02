using CandidateManagement_LeQuangAn.Repo.Models;
using CandidateManagement_LeQuangAn.Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_LeQuangAn.Pages.Candidate
{
    public class CandidateProfileModel : PageModel
    {
        private ICandidateProfileRepo candidateProfileRepo;

        private readonly ILogger<IndexModel> _logger;

        public string Msg { get; set; }

        [BindProperty]
        public IList<CandidateProfile> CandidateProfiles { get; set; }

        [BindProperty]
        public string fullName { get; set; }

        [BindProperty]
        public DateTime birthDay { get; set; }

        public CandidateProfileModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            candidateProfileRepo = new CandidateProfileRepo();
        }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                Response.Redirect("/Index");
            }
            CandidateProfiles = candidateProfileRepo.GetCandidateProfiles();
        }

        //public IActionResult OnPostSearch()
        //{
        //    if (fullName != null && birthDay != null)
        //    {
        //        CandidateProfiles = candidateProfileRepo.searchByFullNameAndBirthDay(fullName, birthDay);
        //    }
        //    else if (birthDay != null)
        //    {
        //        CandidateProfiles = candidateProfileRepo.searchByBirthDay(birthDay);
        //    }

        //    else if (fullName != null)
        //    {
        //        CandidateProfiles = candidateProfileRepo.searchByFullName(fullName);

        //    }

        //    else
        //        CandidateProfiles = candidateProfileRepo.GetCandidateProfiles();
        //    return Page();

        //}

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToPage("/Index");
        }

        public ActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var candidate = candidateProfileRepo.FindCandidate(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return new RedirectToPageResult("Candidate/Edit", candidate);
        }
    }
}