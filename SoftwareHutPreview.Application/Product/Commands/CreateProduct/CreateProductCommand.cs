using MediatR;
using SoftwareHutPreview.Application.Product.ViewModels;

namespace SoftwareHutPreview.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryViewModel Category { get; set; }
        public decimal Price { get; set; }
    }
}
