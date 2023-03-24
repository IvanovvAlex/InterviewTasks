using OnlineStore.Common.Responses.OrderResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Responses.CompanyResponses
{
    public class CompanyWithoutOrdersResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OwnerFullName { get; set; }

        public string UniqueIdentificationCode { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal Capital { get; set; }
    }
}
