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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private OnlineStoreDbContext OnlineStoreDbContext => Context as OnlineStoreDbContext;

        public ProductRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public async Task<Product> Update(Product product)
        {
            string productId = product.Id;

            Product editedProduct = await OnlineStoreDbContext.Products
                .FirstOrDefaultAsync(x => x.Id == productId);

            if (editedProduct == null)
            {
                return null;
            }

            editedProduct.Name = product.Name;
            editedProduct.Description = product.Description;
            editedProduct.Price = product.Price;
            editedProduct.Quantity = product.Quantity;
            editedProduct.File = product.File;

            return editedProduct;
        }
    }
}
