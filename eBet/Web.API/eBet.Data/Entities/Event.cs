using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBet.Data.Entities
{
    public class Event
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ID { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; init; }

        [Required]
        [MaxLength(50)]
        public string CategoryID { get; init; }

        [Required]
        public bool IsLive { get; init; }

        [Required]
        [MaxLength(50)]
        public string SportID { get; init; }
        public Sport Sport { get; init; }
        public ICollection<MatchEvent> Matches { get; init; } = new HashSet<MatchEvent>();
    }
}