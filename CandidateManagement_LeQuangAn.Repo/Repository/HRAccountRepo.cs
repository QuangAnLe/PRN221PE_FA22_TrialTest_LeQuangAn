using CandidateManagement_LeQuangAn.Repo.DataAccess;
using CandidateManagement_LeQuangAn.Repo.Models;

namespace CandidateManagement_LeQuangAn.Repo.Repository;

public class HRAccountRepo : IHRAccountRepo
{
    private HRAccountContext hRAccountContext;

    public HRAccountRepo()
    {
        hRAccountContext = new HRAccountContext();
    }

    public IList<Hraccount> GetUserHraccounts()
    {
        return hRAccountContext.GetUser();
    }
}