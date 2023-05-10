using DevelopSoft.Data.Models;
using DevelopSoft.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DevelopSoft.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace DevelopSoft.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NorthwindContext _context;

        public CustomerController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string companyName, string contactName, string phone, string searchType)
        {
            IQueryable<Customer> query = _context.Customers.Include(c => c.Orders);

            if (!string.IsNullOrWhiteSpace(companyName))
            {
                switch (searchType)
                {
                    case "Equal":
                        query = query.Where(c => c.CompanyName == companyName);
                        break;
                    case "StartsWith":
                        query = query.Where(c => c.CompanyName.StartsWith(companyName));
                        break;
                    case "EndsWith":
                        query = query.Where(c => c.CompanyName.EndsWith(companyName));
                        break;
                    case "Middle":
                        query = query.Where(c => c.CompanyName.Contains(companyName));
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(contactName))
            {
                switch (searchType)
                {
                    case "Equal":
                        query = query.Where(c => c.ContactName == contactName);
                        break;
                    case "StartsWith":
                        query = query.Where(c => c.ContactName.StartsWith(contactName));
                        break;
                    case "EndsWith":
                        query = query.Where(c => c.ContactName.EndsWith(contactName));
                        break;
                    case "Middle":
                        query = query.Where(c => c.ContactName.Contains(contactName));
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                switch (searchType)
                {
                    case "Equal":
                        query = query.Where(c => c.Phone == phone);
                        break;
                    case "StartsWith":
                        query = query.Where(c => c.Phone.StartsWith(phone));
                        break;
                    case "EndsWith":
                        query = query.Where(c => c.Phone.EndsWith(phone));
                        break;
                    case "Middle":
                        query = query.Where(c => c.Phone.Contains(phone));
                        break;
                }
            }

            

            var results = query.Select(c => new CustomerViewModel
            {
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Phone = c.Phone,
                Address = c.Address,
                TotalOrders = c.Orders.Count
            });


            return View(results);
        }
    }
}