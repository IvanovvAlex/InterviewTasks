using System.ComponentModel.DataAnnotations;

namespace eBet.Data.Entities
{
    public class Odd
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ID { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; init; }

        [Required]
        public decimal Value { get; init; }

        public Bet Bet { get; init; }
    }
}