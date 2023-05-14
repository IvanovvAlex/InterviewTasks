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
            try
            {

                ICollection<Customer> query = await _context.Customers.Include(c => c.Orders).AsNoTracking().ToListAsync();

                if (!string.IsNullOrWhiteSpace(companyName))
                {
                    switch (searchType)
                    {
                        case "Equal":
                            query = query.Where(c => c.CompanyName == companyName).ToList();
                            break;
                        case "StartsWith":
                            query = query.Where(c => c.CompanyName.StartsWith(companyName)).ToList();
                            break;
                        case "EndsWith":
                            query = query.Where(c => c.CompanyName.EndsWith(companyName)).ToList();
                            break;
                        case "Middle":
                            query = query.Where(c => c.CompanyName.Contains(companyName)).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(contactName))
                {
                    switch (searchType)
                    {
                        case "Equal":
                            query = query.Where(c => c.ContactName == contactName).ToList();
                            break;
                        case "StartsWith":
                            query = query.Where(c => c.ContactName.StartsWith(contactName)).ToList();
                            break;
                        case "EndsWith":
                            query = query.Where(c => c.ContactName.EndsWith(contactName)).ToList();
                            break;
                        case "Middle":
                            query = query.Where(c => c.ContactName.Contains(contactName)).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    switch (searchType)
                    {
                        case "Equal":
                            query = query.Where(c => c.Phone == phone).ToList();
                            break;
                        case "StartsWith":
                            query = query.Where(c => c.Phone.StartsWith(phone)).ToList();
                            break;
                        case "EndsWith":
                            query = query.Where(c => c.Phone.EndsWith(phone)).ToList();
                            break;
                        case "Middle":
                            query = query.Where(c => c.Phone.Contains(phone)).ToList();
                            break;
                    }
                }

               
                var results = query.Select(c => new CustomerViewModel
                {
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    Phone = c.Phone,
                    Address = c.Address,
                    TotalOrders = c.Orders.Count(),
                });


                return View(results);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}