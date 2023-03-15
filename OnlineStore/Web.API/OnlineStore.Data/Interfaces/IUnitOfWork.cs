using OnlineStore.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        Task<int> CommitAsync();
    }
}
