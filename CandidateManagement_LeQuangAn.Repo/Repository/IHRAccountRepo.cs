using CandidateManagement_LeQuangAn.Repo.Models;

namespace CandidateManagement_LeQuangAn.Repo.Repository;

public interface IHRAccountRepo
{
    IList<Hraccount> GetUserHraccounts();
}