using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.ProductResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Requests.OrderRequests
{
    public class UpdateOrderRequest
    {
        public int Quantity { get; set; }

        public string CompanyId { get; set; }

        public CompanyResponse Company { get; set; }

        public string ProductId { get; set; }

        public ProductResponse Product { get; set; }
    }
}
