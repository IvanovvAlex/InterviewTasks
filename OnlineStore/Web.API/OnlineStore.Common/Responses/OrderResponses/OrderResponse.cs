using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.ProductResponses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Responses.OrderResponses
{
    public class OrderResponse
    {
        public string Id { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; }

        public string CompanyId { get; set; }

        public CompanyResponse Company { get; set; }

        public string ProductId { get; set; }

        public ProductResponse Product { get; set; }
    }
}
