using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> Update(Product product);
    }
}
