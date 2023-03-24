using OnlineStore.Common.Responses.OrderResponses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Requests.CompanyRequests
{
    public class CreateCompanyRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string OwnerFullName { get; set; }

        [Required]
        [MinLength(6)]
        public string UniqueIdentificationCode { get; set; }

        [Required]
        [MinLength(3)]
        public string Country { get; set; }

        [Required]
        [MinLength(3)]
        public string City { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public decimal Capital { get; set; }
    }
}
