using Azure;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private OnlineStoreDbContext OnlineStoreDbContext => Context as OnlineStoreDbContext;

        public CompanyRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public async Task<Company> Update(Company company)
        {

            string companyId = company.Id;

            Company editedCompany = await OnlineStoreDbContext.Companies
                .FirstOrDefaultAsync(x => x.Id == companyId);

            if (editedCompany == null)
            {
                return null;
            }

            editedCompany.Name = company.Name;
            editedCompany.OwnerFullName = company.OwnerFullName;
            editedCompany.UniqueIdentificationCode = company.UniqueIdentificationCode;
            editedCompany.Country = company.Country;
            editedCompany.City = company.City;
            editedCompany.Address = company.Address;
            editedCompany.Email = company.Email;
            editedCompany.Phone = company.Phone;
            editedCompany.Capital = company.Capital;

            return editedCompany;
        }
        public override async ValueTask<Company> GetByIdAsync(string id)
        {
            return await OnlineStoreDbContext.Companies
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public override async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await OnlineStoreDbContext.Companies
                .Include(o => o.Orders)
                .ToListAsync();
        }
    }
}
