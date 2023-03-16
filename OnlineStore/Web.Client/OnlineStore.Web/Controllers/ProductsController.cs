using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Requests.ProductRequests;
using OnlineStore.Common.Responses.ProductResponses;
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
            //ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
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
            //ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Title");

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
            ProductResponse response = await _productService.Update(request);
            if (response == null)
            {
                return NotFound();
            }

            return Redirect($"/Products/Details/{response.Id}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(id);

            return Redirect($"/Products/");
        }
    }
}
