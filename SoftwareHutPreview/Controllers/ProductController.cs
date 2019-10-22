using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftwareHutPreview.Application.Category.Queries.GetAllCategories;
using SoftwareHutPreview.Application.Product.Commands.CreateProduct;
using SoftwareHutPreview.Application.Product.Commands.DeleteProduct;
using SoftwareHutPreview.Application.Product.Commands.UpdateProduct;
using SoftwareHutPreview.Application.Product.Queries.GetAllProducts;
using SoftwareHutPreview.Application.Product.Queries.GetProduct;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Application.ProductType.Queries;

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
          await GetCategories();
          await GetProductTypes();
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateProductCommand command)
        {
            
            if (!ModelState.IsValid)
            {
              await GetCategories();
              await GetProductTypes();
                return View(command);
            }
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
            await GetCategories();
            await GetProductTypes();
            return View("Edit", await Mediator.Send(new GetProductQuery() { Id = id }));
        }

        [HttpPost("{id}"), ActionName("Edit")]
        public async Task<ActionResult<ProductViewModel>> Edit([FromForm]UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                await GetCategories();
                await GetProductTypes();
                return View(command.Adapt<ProductViewModel>());
            }
            await Mediator.Send(command);

            return View("Index", await Mediator.Send(new GetAllProductsQuery()));
        }

        private async Task GetCategories()
        {
            var a = await Mediator.Send(new GetAllCategoriesQuery());
            ViewData["Categories"] = new SelectList(a, "Id", "Name");
        }

        private async Task GetProductTypes()
        {
            var a = await Mediator.Send(new GetAllProductTypeQuery());
            ViewData["ProductTypes"] = new SelectList(a, "Id", "Name");
        }
    }
}
