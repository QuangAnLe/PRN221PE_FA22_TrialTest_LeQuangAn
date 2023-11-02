using CandidateManagement_LeQuangAn.Repo.Models;

namespace CandidateManagement_LeQuangAn.Repo.DataAccess;

public class CandidateProfileContext
{
    private CandidateManagementContext candidateManagementContext;

    public CandidateProfileContext()
    {
        candidateManagementContext = new CandidateManagementContext();
    }

    public List<CandidateProfile> GetCandidateProfiles()
    {
        return candidateManagementContext.CandidateProfiles.ToList();
    }

    public List<CandidateProfile> getCanidatePages(int pageIndex, int pageSize)
    {
        return candidateManagementContext.CandidateProfiles.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
    }

    public int getTotalCandidatePages()
    {
        return candidateManagementContext.CandidateProfiles.Count();
        // return await candidateManagementContext.CandidateProfiles.CountAsync();
    }

    public void AddCandidate(CandidateProfile candidate)
    {
        CandidateProfile can = new CandidateProfile();
        can = getCandidateById(candidate.CandidateId);
        if (can == null)
        {
            candidateManagementContext.CandidateProfiles.Add(candidate);
            candidateManagementContext.SaveChanges();
        }
        else
        {
            Console.WriteLine("Duplicate Candidate");
        }
    }

    public CandidateProfile FindCandidate(string id)
    {
        return candidateManagementContext.CandidateProfiles.Find(id);
    }

    public void UpdateCandidate(CandidateProfile candidate)
    {
        candidateManagementContext.CandidateProfiles.Update(candidate);
        candidateManagementContext.SaveChanges();
    }

    public List<CandidateProfile> searchByFullName(string fullName)
    {
        List<CandidateProfile> listCandidates = null;
        try
        {
            listCandidates = candidateManagementContext.CandidateProfiles.Where(c => c.Fullname.ToUpper().Contains(fullName.ToUpper())).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return listCandidates;
    }

    public List<CandidateProfile> searchByBirthDay(string birthDate)
    {
        List<CandidateProfile> listCandidates = null;
        string dateString = birthDate;
        string format = "dd/MM/yyyy";
        DateTime result = DateTime.ParseExact(dateString, format, null);
        try
        {
            listCandidates = candidateManagementContext.CandidateProfiles.Where(c => c.Birthday.Value == result).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return listCandidates;
    }

    public IList<JobPosting> getJobList()
    {
        return candidateManagementContext.JobPostings.ToList();
    }

    public List<CandidateProfile> searchByFullNameAndBirthDay(string fullName, DateTime birthDay)
    {
        List<CandidateProfile> listCandidates = null;
        try
        {
            listCandidates = candidateManagementContext.CandidateProfiles.Where(c => c.Fullname.ToUpper().Contains(fullName.ToUpper()) && c.Birthday.Value == birthDay).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return listCandidates;
    }

    public void deleteCandidate(string cadidateId)
    {
        try
        {
            var candidate = candidateManagementContext.CandidateProfiles.SingleOrDefault(candidate => candidate.CandidateId == cadidateId);
            if (candidate != null)
            {
                candidateManagementContext.Remove(candidate);
                candidateManagementContext.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void Update(CandidateProfile candidateProfile)
    {
        try
        {
            CandidateProfile _candidate = getCandidateById(candidateProfile.CandidateId);
            if (_candidate != null)
            {
                //candidateManagementContext.Entry<CandidateProfile>(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                candidateManagementContext.CandidateProfiles.Update(candidateProfile);
                candidateManagementContext.SaveChanges();
            }
            else
            {
                throw new Exception("The candidate does not already exist");
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public CandidateProfile getCandidateById(string candidateId)
    {
        CandidateProfile candidate = null;
        try
        {
            using (var context = new CandidateManagementContext())
            {
                candidate = context.CandidateProfiles.SingleOrDefault(can => can.CandidateId == candidateId);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return candidate;
    }
}