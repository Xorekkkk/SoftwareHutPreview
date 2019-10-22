using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using SoftwareHutPreview.Application.Infrastructure.Exceptions;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public CreateProductHandler(SoftwareHutPreviewDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Domain.Entities.Product>();

            var category = await _context.Categories.FindAsync(request.Category.Id);
            var productType = await _context.ProductTypes.FindAsync(request.ProductType.Id);

            product.Category = category;
            product.ProductType = productType;

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
