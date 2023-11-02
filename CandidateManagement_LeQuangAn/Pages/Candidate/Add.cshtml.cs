using CandidateManagement_LeQuangAn.Repo.Models;
using CandidateManagement_LeQuangAn.Repo.Models.ViewModels;
using CandidateManagement_LeQuangAn.Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CandidateManagement_LeQuangAn.Pages.Candidate
{
    public class AddModel : PageModel
    {
        private ICandidateProfileRepo candidateProfileRepo;

        private readonly ILogger<IndexModel> _logger;

        public IList<JobPosting> JobPostings { get; set; }

        [BindProperty]
        public AddCandidateViewModel AddCandidateRequest { get; set; }

        public SelectList PostingIds { get; set; }

        public AddModel(ILogger<IndexModel> logger)
        {
            candidateProfileRepo = new CandidateProfileRepo();
            JobPostings = candidateProfileRepo.getJobList();
            PostingIds = new SelectList(JobPostings, "PostingId", "JobPostingTitle");
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var candidateDomainModel = new CandidateProfile
            {
                CandidateId = AddCandidateRequest.CandidateId,
                Fullname = AddCandidateRequest.Fullname,
                Birthday = AddCandidateRequest.Birthday,
                ProfileShortDescription = AddCandidateRequest.ProfileShortDescription,
                ProfileUrl = AddCandidateRequest.ProfileUrl,
                PostingId = AddCandidateRequest.PostingId,
            };
            candidateProfileRepo.AddCandidate(candidateDomainModel);
            return RedirectToPage("/Candidate/CandidateProfile");
            //  candidateProfileRepo.SaveChanges();
        }
    }
}