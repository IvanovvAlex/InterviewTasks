using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Interfaces.Repositories;
using OnlineStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDbContext _context;

        private readonly ICompanyRepository _companyRepository;

        private readonly IProductRepository _productRepository;

        private readonly IOrderRepository _orderRepository;

        public UnitOfWork(OnlineStoreDbContext context,
            ICompanyRepository companyRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICompanyRepository Companies => _companyRepository ?? new CompanyRepository(_context);

        public IOrderRepository Orders => _orderRepository ?? new OrderRepository(_context);

        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
