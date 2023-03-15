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

        public async Task<Order> Update(Order order)
        {
            string orderId = order.Id;

            Order editedOrder = await OnlineStoreDbContext.Orders
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (editedOrder == null)
            {
                return null;
            }

            editedOrder.TotalPrice = order.TotalPrice;
            editedOrder.Quantity = order.Quantity;
            editedOrder.CompanyId = order.CompanyId;
            editedOrder.Company = order.Company;
            editedOrder.ProductId = order.ProductId;
            editedOrder.Product = order.Product;

            return editedOrder;
        }
    }
}