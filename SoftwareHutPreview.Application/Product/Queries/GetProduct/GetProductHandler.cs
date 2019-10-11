using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Application.Exceptions;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public GetProductHandler(SoftwareHutPreviewDbContext context)
        {
            _context = context;
        }
        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(c => c.Category)
                .Where(x => x.Id == request.Id)
                .SingleAsync(cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request);
            }
            return  product.Adapt<ProductViewModel>();
        }
    }
}
