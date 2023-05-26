using System.ComponentModel.DataAnnotations;

namespace eBet.Data.Entities
{
    public class Bet
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ID { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; init; }

        [Required]
        public bool IsLive { get; init; }

        [Required]
        [MaxLength(50)]
        public string MatchId { get; init; }
        public MatchEvent Match { get; init; }

        public ICollection<Odd> Odds { get; init; } = new HashSet<Odd>();
    }
}