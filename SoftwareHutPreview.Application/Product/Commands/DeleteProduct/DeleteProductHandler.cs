using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoftwareHutPreview.Application.Exceptions;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Commands.DeleteProduct
{
    public  class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public DeleteProductHandler(SoftwareHutPreviewDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            if (_context.Products.Contains(entity))
            {
                throw new DeleteFailureException(nameof(Product), request.Id, "Coś poszło nie tak..");
            }

            return Unit.Value;
        }
    }
}
