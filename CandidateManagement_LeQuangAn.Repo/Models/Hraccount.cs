#nullable disable

namespace CandidateManagement_LeQuangAn.Repo.Models
{
    public partial class Hraccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int? MemberRole { get; set; }
    }
}