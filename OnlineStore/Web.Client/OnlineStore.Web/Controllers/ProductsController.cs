using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.ProductResponses;
using OnlineStore.Core.Enums;
using OnlineStore.Web.Infrastructure.Interfaces;


namespace OnlineStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllProductsResponse> allProducts = await _productService.GetAll();

            return View(allProducts);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(ProductTypes)));

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            ProductResponse response = await _productService.Create(request);

            if (response != null)
            {
                return Redirect($"/Products/Details/{response.Id}");
            }
            return View(request);
        }

        public async Task<IActionResult> Details(string id)
        {
            ProductResponse response = await _productService.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        public async Task<IActionResult> Update(string id)
        {
            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(ProductTypes)));

            ProductResponse model = await _productService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            ProductResponse response = await _productService.Update(request);
            if (response == null)
            {
                return NotFound();
            }

            return Redirect($"/Products/Details/{request.Id}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(id);

            return Redirect($"/Products/");
        }
    }
}
