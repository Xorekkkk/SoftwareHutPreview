using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
