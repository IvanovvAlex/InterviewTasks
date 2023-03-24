using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Repositories;

namespace OnlineStore.Domain.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> Create(string request);

        Task<Company> Update(string request);

        Task Delete(string id);

        Task<Company> GetById(string id);

        Task<IEnumerable<Company>> GetAll();
    }
}
