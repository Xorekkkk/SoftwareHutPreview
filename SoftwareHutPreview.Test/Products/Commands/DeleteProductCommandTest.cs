using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using SoftwareHutPreview.Application.Product.Commands.DeleteProduct;
using SoftwareHutPreview.Test.Infrastructure;
using Xunit;

namespace SoftwareHutPreview.Test.Products.Commands
{
    public class DeleteProductCommandTest : CommandTestBase
    {
        [Fact]
        public async Task DeleteProdctCommandHandlerShouldPass()
        {
            var sut = new DeleteProductHandler(_context);

            var response = await sut.Handle(new DeleteProductCommand {Id = 2}, CancellationToken.None);

            response.Should().Be(Unit.Value);
        }
    }
}
