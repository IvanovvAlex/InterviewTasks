using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> Update(Company company);
    }
}
