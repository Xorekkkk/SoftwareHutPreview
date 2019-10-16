using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using SoftwareHutPreview.Application.Infrastructure.Exceptions;
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

            var response = await sut.Handle(new DeleteProductCommand {Id = 3}, CancellationToken.None);

            response.Should().Be(Unit.Value);
        }

        [Fact]
        public async Task DeleteProductCommandHandlerShouldThrowNotFoundException()
        {
            var sut = new DeleteProductHandler(_context);

            async Task Act() => await sut.Handle(new DeleteProductCommand { Id = 10 }, CancellationToken.None);

            var ex = await Record.ExceptionAsync(Act);

            ex.Should().BeOfType<NotFoundException>();
        }
    }
}
