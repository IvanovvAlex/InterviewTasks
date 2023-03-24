using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Common.Requests.OrderRequests;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Web.Infrastructure.Interfaces;

namespace OnlineStore.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICompanyService _companyService;
        private readonly IProductService _productService;

        public OrdersController(IOrderService orderService, ICompanyService companyService, IProductService productService)
        {
            _orderService = orderService;
            _companyService = companyService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllOrdersResponse> allOrders = await _orderService.GetAll();

            return View(allOrders);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CompanyId"] = new SelectList(await _companyService.GetAll(), "Id", "Name");
            ViewData["ProductId"] = new SelectList(await _productService.GetAll(), "Id", "Name");

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
            ViewData["CompanyId"] = new SelectList(await _companyService.GetAll(), "Id", "Name");
            ViewData["ProductId"] = new SelectList(await _productService.GetAll(), "Id", "Name");

            OrderResponse model = await _orderService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderResponse request)
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
