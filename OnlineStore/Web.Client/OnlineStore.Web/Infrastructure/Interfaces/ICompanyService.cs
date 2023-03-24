using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Responses.CompanyResponses;

namespace OnlineStore.Web.Infrastructure.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyResponse> Create(CreateCompanyRequest request);

        Task<CompanyResponse> Update(UpdateCompanyRequest request);

        Task Delete(string id);

        Task<CompanyResponse> GetById(string id);

        Task<IEnumerable<GetAllCompaniesResponse>> GetAll();
    }
}
