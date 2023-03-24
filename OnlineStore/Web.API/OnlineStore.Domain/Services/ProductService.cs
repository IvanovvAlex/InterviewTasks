using AutoMapper;
using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.ProductResponses;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Product> Create(string request)
        {
            Product newProduct = JsonSerializer.Deserialize<Product>(request, _serializerOptions);

            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }

        public async Task Delete(string id)
        {
            Product product = await GetById(id);
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<Product> Update(string request)
        {
            Product product = JsonSerializer.Deserialize<Product>(request, _serializerOptions);

            await _unitOfWork.Products.Update(product);
            await _unitOfWork.CommitAsync();
            return product;
        }
    }
}
