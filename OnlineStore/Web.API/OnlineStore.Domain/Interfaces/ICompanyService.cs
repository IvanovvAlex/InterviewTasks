using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Repositories;

namespace OnlineStore.Domain.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> Create(Company newCompany);

        Task<Company> Update(Company request);

        Task Delete(string id);

        Task<Company> GetById(string id);

        Task<IEnumerable<Company>> GetAll();
    }
}
