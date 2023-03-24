using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Responses.OrderResponses;

namespace OnlineStore.Web.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> Create(CreateOrderRequest request);

        Task<OrderResponse> Update(OrderResponse request);
        
        Task Delete(string id);
        
        Task<OrderResponse> GetById(string id);
        
        Task<IEnumerable<GetAllOrdersResponse>> GetAll();
    }
}
