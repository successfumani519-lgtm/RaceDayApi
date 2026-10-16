using System.ComponentModel.DataAnnotations;

namespace RaceDayApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        // Navigation properties
        public Organiser? Organiser { get; set; }
        public Participant? Participant { get; set; }
    }
}
