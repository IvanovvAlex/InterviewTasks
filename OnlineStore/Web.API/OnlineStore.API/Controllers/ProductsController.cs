using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.ProductResponses;
using OnlineStore.Data.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Domain.Services;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<ProductResponse> Create(CreateProductRequest request)
        {
            Product product = _mapper.Map<CreateProductRequest, Product>(request);
            ProductResponse productResponse = _mapper.Map<Product, ProductResponse>(await _productService.Create(product));

            return productResponse;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<GetAllProductsResponse>> GetAll()
        {
            IEnumerable<Product> products = await _productService.GetAll();

            IEnumerable<GetAllProductsResponse> allProductsResponse = _mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsResponse>>(products);

            return allProductsResponse;
        }

        [HttpGet("Details")]
        public async Task<ProductResponse> Details(string id)
        {
            Product product = await _productService.GetById(id);

            ProductResponse productResponse = _mapper.Map<Product, ProductResponse>(product);

            return productResponse;
        }

        [HttpPut("Update")]
        public async Task<ProductResponse> Update(UpdateProductRequest request)
        {

            Product product = await _productService.Update(_mapper.Map<UpdateProductRequest, Product>(request));

            ProductResponse productResponse = _mapper.Map<Product, ProductResponse>(product);

            return productResponse;
        }

        [HttpDelete("Delete")]
        public async Task DeleteById(string id)
        {
            await _productService.Delete(id);
        }
    }
}
