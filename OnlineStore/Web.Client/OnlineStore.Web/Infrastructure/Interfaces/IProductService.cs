using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.ProductResponses;
using OnlineStore.Data.Entities;

namespace OnlineStore.Web.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> Create(CreateProductRequest request);

        Task<ProductResponse> Update(UpdateProductRequest request);

        Task Delete(string id);

        Task<ProductResponse> GetById(string id);

        Task<IEnumerable<GetAllProductsResponse>> GetAll();
    }
}
