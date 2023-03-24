using AutoMapper;
using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Common.Responses.ProductResponses;
using OnlineStore.Data.Entities;

namespace OnlineStore.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Company mappings
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<Company, CreateCompanyRequest>();

            CreateMap<Company, CompanyResponse>();
            CreateMap<CompanyResponse, Company>();

            CreateMap<Company, GetAllCompaniesResponse>();
            CreateMap<GetAllCompaniesResponse, Company>();

            CreateMap<Company, UpdateCompanyRequest>();
            CreateMap<UpdateCompanyRequest, Company>();

            CreateMap<Company, CompanyWithoutOrdersResponse>();
            CreateMap<CompanyWithoutOrdersResponse, Company>();

            //Product mappings
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreateProductRequest>();

            CreateMap<Product, ProductResponse>();
            CreateMap<ProductResponse, Product>();

            CreateMap<Product, GetAllProductsResponse>();
            CreateMap<GetAllProductsResponse, Product>();

            CreateMap<Product, UpdateProductRequest>();
            CreateMap<UpdateProductRequest, Product>();

            CreateMap<Product, ProductWithoutOrdersResponse>();
            CreateMap<ProductWithoutOrdersResponse, Product>();

            //Order mappings
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, CreateOrderRequest>();

            CreateMap<Order, OrderResponse>();
            CreateMap<OrderResponse, Order>();

            CreateMap<Order, GetAllOrdersResponse>();
            CreateMap<GetAllOrdersResponse, Order>();

            CreateMap<Order, UpdateOrderRequest>();
            CreateMap<UpdateOrderRequest, Order>();
        }
    }
}
