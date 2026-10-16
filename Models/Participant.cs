using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayApi.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}
