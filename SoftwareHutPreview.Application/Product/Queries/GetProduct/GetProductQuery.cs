using MediatR;
using SoftwareHutPreview.Application.Product.ViewModels;

namespace SoftwareHutPreview.Application.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
