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

namespace SoftwareHutPreview.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IList<CategoryViewModel>>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public GetAllCategoriesHandler(SoftwareHutPreviewDbContext context)
        {
            _context = context;
        }
        public async Task<IList<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.ToListAsync(cancellationToken);

            return result.Adapt<IList<CategoryViewModel>>();
        }
    }
}
