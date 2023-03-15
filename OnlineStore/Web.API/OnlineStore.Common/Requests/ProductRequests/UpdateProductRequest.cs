using OnlineStore.Common.Responses.OrderResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Requests.ProductRequests
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string File { get; set; } //TO DO
    }
}
