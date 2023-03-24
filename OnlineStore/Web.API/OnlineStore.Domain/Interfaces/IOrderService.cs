using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<Order> Create(string request);

        Task<Order> Update(string request);

        Task Delete(string id); 

        Task<Order> GetById(string id);

        Task<IEnumerable<Order>> GetAll();
    }
}
