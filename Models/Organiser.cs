using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayApi.Models
{
    public class Organiser
    {
        [Key]
        public int OrganiserId { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(200)]
        public string? CompanyName { get; set; }

        [Required]
        [MaxLength(20)]
        public string ContactPhone { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
