using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace eBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        [HttpGet]
        public async Task<ICollection<string>> GetAll()
        {
            //IEnumerable<Company> companies = await _companyService.GetAll();

            //IEnumerable<GetAllCompaniesResponse> allCompaniesResponse = _mapper.Map<IEnumerable<Company>, IEnumerable<GetAllCompaniesResponse>>(companies);

            //return allCompaniesResponse;
            return new string[] { "value1", "value2" };
        }
    }
}
