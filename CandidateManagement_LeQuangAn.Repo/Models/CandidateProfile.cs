using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_LeQuangAn.Repo.Models
{
    public class CandidateProfile
    {
        [Required]
        public string CandidateId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Each word of the candidate Fullname must begin with the capital letter. ")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "FullName must be exactly 13 characters long.")]
        public string Fullname { get; set; }

        [Required]
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 12, ErrorMessage = "Profile description must be between 12 and 200 characters.")]
        public string ProfileShortDescription { get; set; }

        [Required]
        public string ProfileUrl { get; set; }

        [Required]
        public string PostingId { get; set; }

        public virtual JobPosting Posting { get; set; }
    }
}