using CandidateManagement_LeQuangAn.Repo.Models;

namespace CandidateManagement_LeQuangAn.Repo.DataAccess;

public class HRAccountContext
{
    private CandidateManagementContext candidateManagementContext;

    public HRAccountContext()
    {
        candidateManagementContext = new CandidateManagementContext();
    }

    public IList<Hraccount> GetUser()
    {
        return candidateManagementContext.Hraccounts.ToList();
    }
}