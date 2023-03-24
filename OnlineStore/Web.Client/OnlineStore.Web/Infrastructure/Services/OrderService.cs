using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Web.Infrastructure.Interfaces;
using System.Text.Json;

namespace OnlineStore.Web.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");

            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase

            };
        }


        public async Task<OrderResponse> Create(CreateOrderRequest request)
        {
            string requestJson = JsonSerializer.Serialize<CreateOrderRequest>(request, _serializerOptions);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Orders/Create", requestJson);
            string responseContent = await response.Content.ReadAsStringAsync();

            OrderResponse order = JsonSerializer.Deserialize<OrderResponse>(responseContent, _serializerOptions);

            return order;
        }

        public async Task Delete(string id)
        {
            await _httpClient.DeleteAsync($"/api/Orders/Delete/{id}");
        }

        public async Task<IEnumerable<GetAllOrdersResponse>> GetAll()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Orders/GetAll");
            string responseContent = await response.Content.ReadAsStringAsync();

            ICollection<GetAllOrdersResponse> allOrders = JsonSerializer.Deserialize<ICollection<GetAllOrdersResponse>>(responseContent, _serializerOptions);

            return allOrders;
        }

        public async Task<OrderResponse> GetById(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Orders/Details/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();

            OrderResponse order = JsonSerializer.Deserialize<OrderResponse>(responseContent, _serializerOptions);

            return order;
        }

        public async Task<OrderResponse> Update(OrderResponse request)
        {
            string requestJson = JsonSerializer.Serialize<OrderResponse>(request, _serializerOptions);

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/api/Orders/Update", requestJson);
            string responseContent = await response.Content.ReadAsStringAsync();

            OrderResponse order = JsonSerializer.Deserialize<OrderResponse>(responseContent, _serializerOptions);

            return order;
        }
    }
}
