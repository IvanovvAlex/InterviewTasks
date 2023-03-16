using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Data.Entities;

namespace OnlineStore.Web.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> Create(CreateOrderRequest request);

        Task<OrderResponse> Update(UpdateOrderRequest request);
        
        Task Delete(string id);
        
        Task<OrderResponse> GetById(string id);
        
        Task<IEnumerable<GetAllOrdersResponse>> GetAll();
    }
}
