using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineStore.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private OnlineStoreDbContext OnlineStoreDbContext => Context as OnlineStoreDbContext;

        public OrderRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public override async Task<bool> AddAsync(Order entity)
        {
            Product product = await OnlineStoreDbContext.Products.FirstOrDefaultAsync(p => p.Id == entity.ProductId);
            decimal productPrice = product.Price;
            if (product.Quantity >= entity.Quantity)
            {
                product.Quantity -= entity.Quantity;
                entity.TotalPrice = entity.Quantity * productPrice;
                await Context.Set<Order>().AddAsync(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Order> Update(Order editedOrder)
        {
            string orderId = editedOrder.Id;

            Order order = await OnlineStoreDbContext.Orders
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return null;
            }

            Product product = await OnlineStoreDbContext.Products.FirstOrDefaultAsync(p => p.Id == editedOrder.ProductId);
            decimal productPrice = product.Price;
            if (editedOrder.Quantity > order.Quantity)
            {
                product.Quantity -= Math.Abs(editedOrder.Quantity - order.Quantity);
            }
            else
            {
                product.Quantity += Math.Abs(order.Quantity - editedOrder.Quantity);
            }

            order.TotalPrice = editedOrder.Quantity * productPrice;
            order.Quantity = editedOrder.Quantity;
            order.CompanyId = editedOrder.CompanyId;
            order.ProductId = editedOrder.ProductId;

            return order;
        }

        public override async ValueTask<Order> GetByIdAsync(string id)
        {
            return await OnlineStoreDbContext.Orders
                .Include(c => c.Company)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await OnlineStoreDbContext.Orders
                .Include(c => c.Company)
                .Include(p => p.Product)
                .ToListAsync();
        }
    }
}