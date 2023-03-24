using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Data.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<OrderResponse> Create([FromBody]string request)
        {
            Order order = await _orderService.Create(request);
            OrderResponse orderResponse = _mapper.Map<Order, OrderResponse>(order);

            return orderResponse;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<GetAllOrdersResponse>> GetAll()
        {
            IEnumerable<Order> orders = await _orderService.GetAll();

            IEnumerable<GetAllOrdersResponse> allOrdersResponse = _mapper.Map<IEnumerable<Order>, IEnumerable<GetAllOrdersResponse>>(orders);

            return allOrdersResponse;
        }

        [HttpGet("Details/{id}")]
        public async Task<OrderResponse> Details(string id)
        {
            Order order = await _orderService.GetById(id);

            OrderResponse orderResponse = _mapper.Map<Order, OrderResponse>(order);

            return orderResponse;
        }

        [HttpPut("Update")]
        public async Task<OrderResponse> Update([FromBody]string request)
        {

            Order order = await _orderService.Update(request);

            OrderResponse orderResponse = _mapper.Map<Order, OrderResponse>(order);

            return orderResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task DeleteById(string id)
        {
            await _orderService.Delete(id);
        }
    }
}
