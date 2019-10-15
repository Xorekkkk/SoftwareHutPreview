using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentAssertions;
using Mapster;
using SoftwareHutPreview.Application.Product.Commands.CreateProduct;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Test.Infrastructure;
using Xunit;

namespace SoftwareHutPreview.Test.Products.Commands
{
    public class CreateProductCommandTest : CommandTestBase
    {
        [Fact]
        public async void CreatedProductShouldReturnId()
        {
            var sut = new CreateProductHandler(_context);

            var response = await sut
                .Handle(
                    new CreateProductCommand
                    {
                        Name = "Intel i9-9900k",
                        Description = "Nowy niezawodny",
                        Category = 1.Adapt<CategoryViewModel>()
                    }, CancellationToken.None);

            response.Should().BeOfType(typeof(int));

        }
    }
}
