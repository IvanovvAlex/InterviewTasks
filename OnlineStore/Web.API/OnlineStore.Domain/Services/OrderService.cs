using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineStore.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Create(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }

        public async Task Delete(string id)
        {
            Order order = await GetById(id);
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> GetById(string id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }

        public async Task<Order> Update(Order order)
        {
            await _unitOfWork.Orders.Update(order);
            await _unitOfWork.CommitAsync();
            return order;
        }
    }
}
