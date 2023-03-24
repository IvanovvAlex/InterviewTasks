using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Data.Entities;
using OnlineStore.Domain.Interfaces;
using System.Text.Json;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<CompanyResponse> Create([FromBody] string request)
        {
            Company company = await _companyService.Create(request);
            CompanyResponse companyResponse = _mapper.Map<Company, CompanyResponse>(company);

            return companyResponse;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<GetAllCompaniesResponse>> GetAll()
        {
            IEnumerable<Company> companies = await _companyService.GetAll();

            IEnumerable<GetAllCompaniesResponse> allCompaniesResponse = _mapper.Map<IEnumerable<Company>, IEnumerable<GetAllCompaniesResponse>>(companies);

            return allCompaniesResponse;
        }

        [HttpGet("Details/{id}")]
        public async Task<CompanyResponse> Details(string id)
        {
            Company company = await _companyService.GetById(id);

            CompanyResponse companyResponse = _mapper.Map<Company, CompanyResponse>(company);

            return companyResponse;
        }

        [HttpPut("Update")]
        public async Task<CompanyResponse> Update([FromBody] string request)
        {

            Company company = await _companyService.Update(request);

            CompanyResponse companyResponse = _mapper.Map<Company, CompanyResponse>(company);

            return companyResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(string id)
        {
            await _companyService.Delete(id);
        }
    }
}
