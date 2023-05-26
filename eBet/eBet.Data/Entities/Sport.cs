using System.ComponentModel.DataAnnotations;

namespace eBet.Data.Entities
{
    public class Sport
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ID { get; init; }

        [Required]
        [MaxLength(100)]
        public string Name { get; init; }

        public ICollection<Event> Events { get; init; } = new HashSet<Event>();
    }
}