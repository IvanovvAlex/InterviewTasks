using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Web.Infrastructure.Interfaces;

namespace OnlineStore.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllOrdersResponse> allOrders = await _orderService.GetAll();

            return View(allOrders);
        }

        public async Task<IActionResult> Create()
        {
            //ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            OrderResponse response = await _orderService.Create(request);

            if (response != null)
            {
                return Redirect($"/Orders/Details/{response.Id}");
            }
            return View(request);
        }

        public async Task<IActionResult> Details(string id)
        {
            OrderResponse response = await _orderService.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        public async Task<IActionResult> Update(string id)
        {
            //ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Title");

            OrderResponse model = await _orderService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderRequest request)
        {
            OrderResponse response = await _orderService.Update(request);
            if (response == null)
            {
                return NotFound();
            }

            return Redirect($"/Orders/Details/{response.Id}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _orderService.Delete(id);

            return Redirect($"/Orders/");
        }
    }
}
