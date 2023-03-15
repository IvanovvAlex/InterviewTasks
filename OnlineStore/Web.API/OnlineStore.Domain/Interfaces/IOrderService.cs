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
        Task<Order> Create(Order newOrder);

        Task<Order> Update(Order order);

        Task Delete(string id); 
        Task<Order> GetById(string id);

        Task<IEnumerable<Order>> GetAll();
    }
}
