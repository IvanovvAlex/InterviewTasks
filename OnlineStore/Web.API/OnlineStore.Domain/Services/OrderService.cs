using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineStore.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JsonSerializerOptions _serializerOptions;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Order> Create(string request)
        {
            Order order = JsonSerializer.Deserialize<Order>(request, _serializerOptions);

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return order;
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

        public async Task<Order> Update(string request)
        {
            Order order = JsonSerializer.Deserialize<Order>(request, _serializerOptions);

            await _unitOfWork.Orders.Update(order);
            await _unitOfWork.CommitAsync();
            return order;
        }
    }
}
