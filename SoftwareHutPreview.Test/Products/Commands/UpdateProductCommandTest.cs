using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentAssertions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Application.Product.Commands.UpdateProduct;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Test.Infrastructure;
using Xunit;

namespace SoftwareHutPreview.Test.Products.Commands
{
    public class UpdateProductCommandTest : CommandTestBase
    {
        [Fact]
        public async void UpdateProductHandlerShouldReturnId()
        {
            var sut = new UpdateProductHandler(_context);
            var category = await _context.Categories.FirstOrDefaultAsync();
            var result = await sut.Handle(new UpdateProductCommand {
                    Description = "Zmieniono",
                Name = "Ryzen 4600fx",
                Category = category.Adapt<CategoryViewModel>(),
                Price = 1200

            },
                CancellationToken.None);

            var changed = await _context.Products.FirstAsync(x => x.Id == result);
            result.Should().BeOfType(typeof(int));
            changed.Description.Should().Be("Zmieniono");
        }
    }
}
