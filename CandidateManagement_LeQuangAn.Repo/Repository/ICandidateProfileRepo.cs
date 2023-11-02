using CandidateManagement_LeQuangAn.Repo.Models;

namespace CandidateManagement_LeQuangAn.Repo.Repository;

public interface ICandidateProfileRepo
{
    List<CandidateProfile> GetCandidateProfiles();

    void AddCandidate(CandidateProfile candidateProfileRequest);

    CandidateProfile FindCandidate(string id);

    void UpdateCandidate(CandidateProfile candidateProfileRequest);

    List<CandidateProfile> searchByFullName(string fullName);

    List<CandidateProfile> searchByBirthDay(string birthDay);

    IList<JobPosting> getJobList();

    List<CandidateProfile> searchByFullNameAndBirthDay(string fullName, DateTime birthDay);

    void deleteCandidate(string candidateId);

    void updateCandidate(CandidateProfile candidateProfile);

    CandidateProfile getCandidateProfileById(string id);

    public List<CandidateProfile> getCandidatesPages(int pageSize, int pageIndex);

    public int getTotalCandidatesPages();
}