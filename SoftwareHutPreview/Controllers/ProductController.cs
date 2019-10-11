using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareHutPreview.Application.Product.Queries.GetProduct;

namespace SoftwareHutPreview.Api.Controllers
{
    public class ProductController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> Index()
        {
            return View("Index");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Details(int id)
        {
            return View("Details", await Mediator.Send(new GetProductQuery() { Id = id }));
        }
    }
}
