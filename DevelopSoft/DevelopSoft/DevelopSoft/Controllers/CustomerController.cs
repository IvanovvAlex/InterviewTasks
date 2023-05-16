using DevelopSoft.Data.Models;
using DevelopSoft.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DevelopSoft.Models.Customer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using DevelopSoft.Services.Customers;

namespace DevelopSoft.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly ICustomerService _cusomerService;

        public CustomerController(NorthwindContext context, ICustomerService customerService)
        {
            _context = context;
            _cusomerService = customerService;           
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] string company)
        {
            try
            {
                IFormCollection requestForm = Request.Form;

                IEnumerable<CustomerViewModel> results = await _cusomerService.SearchAsync(requestForm);

                return View(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}