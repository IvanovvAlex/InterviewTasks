using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Models
{
    public class Order
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
       
        [Required]
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
