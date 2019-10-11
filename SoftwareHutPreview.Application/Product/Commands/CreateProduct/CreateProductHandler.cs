using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using SoftwareHutPreview.Application.Product.ViewModels;
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

            product.Category = category;

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
