using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.ProductResponses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Requests.OrderRequests
{
    public class CreateOrderRequest
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public string CompanyId { get; set; }

        public CompanyResponse Company { get; set; }

        [Required]
        public string ProductId { get; set; }

        public ProductResponse Product { get; set; }
    }
}
