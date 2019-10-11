using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Application.Exceptions;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>

    {
    private readonly SoftwareHutPreviewDbContext _context;

    public UpdateProductHandler(SoftwareHutPreviewDbContext context)
    {
        _context = context;
    }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = request.Adapt<Domain.Entities.Product>();
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request);
            }

            var entity = await _context.Products.SingleOrDefaultAsync(c => c.Id == product.Id, cancellationToken);
            var category = await _context.Categories.FindAsync(product.Category.Id);

            entity = product;

            entity.Category = category;

             _context.Products.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
