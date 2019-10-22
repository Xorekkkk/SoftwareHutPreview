using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.ProductType.Queries
{
    public class GetAllProductTypeHandler : IRequestHandler<GetAllProductTypeQuery, IList<ProductTypeViewModel>>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public GetAllProductTypeHandler(SoftwareHutPreviewDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ProductTypeViewModel>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.ProductTypes.ToListAsync(cancellationToken);

            return result.Adapt<IList<ProductTypeViewModel>>();
        }
    }
}
