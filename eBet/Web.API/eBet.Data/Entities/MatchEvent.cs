using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBet.Data.Entities
{
    [Table("Match")]
    public class MatchEvent
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
        public string MatchType { get; init; }

        [Required]
        public DateTime StartDate { get; init; }

        [Required]
        [MaxLength(50)]
        public string EventID { get; init; }
        public Event Event { get; init; }

        public ICollection<Bet> Bets { get; init; } = new HashSet<Bet>();
    }
}