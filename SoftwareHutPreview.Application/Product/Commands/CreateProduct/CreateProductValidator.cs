using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Application.Product.Commands.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly SoftwareHutPreviewDbContext _context;

        public CreateProductValidator(SoftwareHutPreviewDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Must(BeUnique).WithMessage("Produkt musi mieć unikalną nazwę.")
                .MaximumLength(60);
            RuleFor(d => d.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(60);
            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThan(0.0m).WithMessage("Wartość pola cena musi być większa od 0");
        }

        //Bonus
        private bool BeUnique(CreateProductCommand command, string name, PropertyValidatorContext ctx)
        {
            return _context.Products.All(x => x.Name != command.Name);
        }

        


    }
}
