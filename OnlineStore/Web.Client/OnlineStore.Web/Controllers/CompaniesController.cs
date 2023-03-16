using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Web.Infrastructure.Interfaces;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;

namespace OnlineStore.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllCompaniesResponse> allCompanies = await _companyService.GetAll();

            return View(allCompanies);
        }

        public async Task<IActionResult> Create()
        {
            //ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyRequest request)
        {
            CompanyResponse response = await _companyService.Create(request);

            if (response != null)
            {
                return Redirect($"/Companies/Details/{response.Id}");
            }
            return View(request);
        }

        public async Task<IActionResult> Details(string id)
        {
            CompanyResponse response = await _companyService.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        public async Task<IActionResult> Update(string id)
        {
            //ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Title");

            CompanyResponse model = await _companyService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCompanyRequest request)
        {
            CompanyResponse response = await _companyService.Update(request);
            if (response == null)
            {
                return NotFound();
            }

            return Redirect($"/Companies/Details/{response.Id}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _companyService.Delete(id);
            
            return Redirect($"/Companies/");
        }
    }
}
