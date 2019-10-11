using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
