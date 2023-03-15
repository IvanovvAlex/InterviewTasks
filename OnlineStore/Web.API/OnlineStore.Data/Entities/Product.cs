using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class Product
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string File { get; set; } //TO DO!

        public bool IsDeleted { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
