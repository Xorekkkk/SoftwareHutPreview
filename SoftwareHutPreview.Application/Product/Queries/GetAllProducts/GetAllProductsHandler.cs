using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductViewModel>>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public GetAllProductsHandler(SoftwareHutPreviewDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Include(c => c.Category)
                .ToListAsync(cancellationToken);
            
            return products.Adapt<IList<ProductViewModel>>();
        }
    }
}
