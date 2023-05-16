using Azure.Core;
using DevelopSoft.Data;
using DevelopSoft.Models.Customer;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DevelopSoft.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DevelopSoft.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly NorthwindContext _context;

        public CustomerService(NorthwindContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomerViewModel>> SearchAsync(IFormCollection requestForm)
        {
            ICollection<Customer> results = await _context.Customers.Include(c => c.Orders).ToListAsync();


            requestForm.TryGetValue("companyName", out var companyName);
            requestForm.TryGetValue("companyNameSearchType", out var companyNameSearchType);

            requestForm.TryGetValue("contactName".ToLower(), out var contactName);
            requestForm.TryGetValue("contactNameSearchType", out var contactNameSearchType);

            requestForm.TryGetValue("phone".ToLower(), out var phone);
            requestForm.TryGetValue("phoneSearchType", out var phoneSearchType);


            if (!string.IsNullOrWhiteSpace(companyName))
            {
                switch (companyNameSearchType)
                {
                    case "Equal":
                        results = results.Where(c => c.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "Startswith":
                        results = results.Where(c => c.CompanyName.StartsWith(companyName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "Endswith":
                        results = results.Where(c => c.CompanyName.EndsWith(companyName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "Middle":
                        results = results.Where(c => c.CompanyName.Contains(companyName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(contactName))
            {
                switch (contactNameSearchType)
                {
                    case "Equal":
                        results = results.Where(c => c.ContactName.Equals(contactName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "StartsWith":
                        results = results.Where(c => c.ContactName.StartsWith(contactName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "EndsWith":
                        results = results.Where(c => c.ContactName.EndsWith(contactName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "Middle":
                        results = results.Where(c => c.ContactName.Contains(contactName, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                switch (phoneSearchType)
                {
                    case "Equal":
                        results = results.Where(c => c.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "StartsWith":
                        results = results.Where(c => c.Phone.StartsWith(phone, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "EndsWith":
                        results = results.Where(c => c.Phone.EndsWith(phone, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "Middle":
                        results = results.Where(c => c.Phone.Contains(phone, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                }
            }


            return results.Select(c => new CustomerViewModel
            {
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Phone = c.Phone,
                Address = c.Address,
                TotalOrders = c.Orders.Count(),
            });
        }
    }
}
