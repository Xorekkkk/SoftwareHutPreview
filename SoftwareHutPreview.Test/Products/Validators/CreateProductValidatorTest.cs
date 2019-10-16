using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mapster;
using SoftwareHutPreview.Application.Product.Commands.CreateProduct;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Test.Infrastructure;
using Xunit;

namespace SoftwareHutPreview.Test.Products.Validators
{
    public class CreateProductValidatorTest : CommandTestBase
    {
        [Fact]
        public async Task CreateProductValidatorShouldPass()
        {
            var validator = new CreateProductValidator(_context);
            var command =
                new CreateProductCommand
                {
                    Name = "Intel i9-9900k",
                    Description = "Nowy niezawodny",
                    Category = 1.Adapt<CategoryViewModel>(),
                    Price = 1200,
                };

            var validationResult = await validator.ValidateAsync(command);

            validationResult.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task CreateProductValidatorShouldReturnEmptyNameError()
        {
            var validator = new CreateProductValidator(_context);
            var command = new CreateProductCommand
            {
                Name = "",
                Description = "Nowy niezawodny",
                Category = 1.Adapt<CategoryViewModel>(),
                Price = 1200,
            };

            var validationResult = await validator.ValidateAsync(command);

            validationResult.Errors.Count.Should().Be(1);

        }
    }
}
