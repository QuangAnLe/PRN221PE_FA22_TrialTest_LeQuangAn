using CandidateManagement_LeQuangAn.Repo.Models.ViewModels;
using CandidateManagement_LeQuangAn.Repo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_LeQuangAn.Pages.Candidate;

public class EditModel : PageModel
{
    [BindProperty]
    public EditCandidateViewModel EditCandidateViewModel { get; set; }

    private ICandidateProfileRepo candidateProfileRepo;

    private readonly ILogger<IndexModel> _logger;

    public EditModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        candidateProfileRepo = new CandidateProfileRepo();
    }

    public void OnGet(string CandidateId)
    {
        var candidate = candidateProfileRepo.FindCandidate(CandidateId);

        if (candidate != null)
        {
            EditCandidateViewModel = new EditCandidateViewModel()
            {
                CandidateId = candidate.CandidateId,
                Fullname = candidate.Fullname,
                Birthday = candidate.Birthday,
                ProfileShortDescription = candidate.ProfileShortDescription,
                ProfileUrl = candidate.ProfileUrl,
                PostingId = candidate.PostingId
            };
        }
    }

    public void OnPost()
    {
        if (EditCandidateViewModel != null)
        {
            var existingCandidate = candidateProfileRepo.FindCandidate(EditCandidateViewModel.CandidateId);
            if (existingCandidate != null)
            {
                //Convert ViewModel to DomainModel
                existingCandidate.CandidateId = EditCandidateViewModel.CandidateId;
                existingCandidate.Fullname = EditCandidateViewModel.Fullname;
                existingCandidate.Birthday = EditCandidateViewModel.Birthday;
                existingCandidate.ProfileShortDescription = EditCandidateViewModel.ProfileShortDescription;
                existingCandidate.ProfileUrl = EditCandidateViewModel.ProfileUrl;
                existingCandidate.PostingId = EditCandidateViewModel.PostingId;
                candidateProfileRepo.UpdateCandidate(existingCandidate);
            }
        }
    }
}