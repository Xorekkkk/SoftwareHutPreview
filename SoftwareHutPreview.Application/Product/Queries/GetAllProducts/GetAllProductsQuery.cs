using System.Collections.Generic;
using MediatR;
using SoftwareHutPreview.Application.Product.ViewModels;

namespace SoftwareHutPreview.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IList<ProductViewModel>>
    {
    }
}
