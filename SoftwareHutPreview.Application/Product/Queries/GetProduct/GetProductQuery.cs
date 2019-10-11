using MediatR;

namespace SoftwareHutPreview.Application.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
