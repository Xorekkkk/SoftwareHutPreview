using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftwareHutPreview.Application.Category.Queries.GetAllCategories;
using SoftwareHutPreview.Application.Product.Commands.CreateProduct;
using SoftwareHutPreview.Application.Product.Commands.DeleteProduct;
using SoftwareHutPreview.Application.Product.Commands.UpdateProduct;
using SoftwareHutPreview.Application.Product.Queries.GetAllProducts;
using SoftwareHutPreview.Application.Product.Queries.GetProduct;
using SoftwareHutPreview.Application.Product.ViewModels;

namespace SoftwareHutPreview.Api.Controllers
{
    public class ProductController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> Index()
        {
            return View("Index", await Mediator.Send(new GetAllProductsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Details(int id)
        {
            return View("Details", await Mediator.Send(new GetProductQuery() { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var a = await Mediator.Send(new GetAllCategoriesQuery());
            ViewData["Categories"] = new SelectList(a, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateProductCommand command)
        {
            await Mediator.Send(command);

            return View("Index", await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpPost("{id}"), ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Edit(int id)
        {
            var a = await Mediator.Send(new GetAllCategoriesQuery());
            ViewData["Categories"] = new SelectList(a, "Id", "Name");

            return View("Edit", await Mediator.Send(new GetProductQuery() { Id = id }));
        }

        [HttpPost("{id}"), ActionName("Edit")]
        public async Task<ActionResult<ProductViewModel>> Edit([FromForm]UpdateProductCommand command)
        {
            await Mediator.Send(command);

            return View("Index", await Mediator.Send(new GetAllProductsQuery()));
        }
    }
}
