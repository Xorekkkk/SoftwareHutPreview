using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using SoftwareHutPreview.Application.Product.Commands.CreateProduct;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public UpdateProductValidator(SoftwareHutPreviewDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(60);
            RuleFor(d => d.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(60);
            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThan(0.0m).WithMessage("Wartość pola cena musi być większa od 0");

        }
    }
}
