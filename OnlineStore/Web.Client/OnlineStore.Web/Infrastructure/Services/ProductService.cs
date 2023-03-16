using Azure.Core;
using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Common.Responses.ProductResponses;
using OnlineStore.Web.Infrastructure.Interfaces;
using System.Text.Json;

namespace OnlineStore.Web.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");

            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<ProductResponse> Create(CreateProductRequest request)
        {
            string requestJson = JsonSerializer.Serialize<CreateProductRequest>(request, _serializerOptions);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Products/Create", requestJson);
            string responseContent = await response.Content.ReadAsStringAsync();

            ProductResponse product = JsonSerializer.Deserialize<ProductResponse>(responseContent, _serializerOptions);

            return product;
        }

        public async Task Delete(string id)
        {
            await _httpClient.GetAsync($"/api/Products/Delete/{id}");
        }

        public async Task<IEnumerable<GetAllProductsResponse>> GetAll()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Products/GetAll");
            string responseContent = await response.Content.ReadAsStringAsync();

            ICollection<GetAllProductsResponse> allProducts = JsonSerializer.Deserialize<ICollection<GetAllProductsResponse>>(responseContent, _serializerOptions);

            return allProducts;
        }

        public async Task<ProductResponse> GetById(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Products/Details/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();

            ProductResponse product = JsonSerializer.Deserialize<ProductResponse>(responseContent, _serializerOptions);

            return product;
        }

        public async Task<ProductResponse> Update(UpdateProductRequest request)
        {
            string requestJson = JsonSerializer.Serialize<UpdateProductRequest>(request, _serializerOptions);

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/api/Products/Update", requestJson);
            string responseContent = await response.Content.ReadAsStringAsync();

            ProductResponse product = JsonSerializer.Deserialize<ProductResponse>(responseContent, _serializerOptions);
                
            return product;
        }
    }
}
