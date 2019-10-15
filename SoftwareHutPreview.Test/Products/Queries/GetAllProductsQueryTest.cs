using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mapster;
using SoftwareHutPreview.Application.Product.Queries.GetAllProducts;
using SoftwareHutPreview.Application.Product.ViewModels;
using SoftwareHutPreview.Test.Infrastructure;
using Xunit;

namespace SoftwareHutPreview.Test.Products.Queries
{
    public class GetAllProductsQueryTest : CommandTestBase
    {
        [Fact]
        public async Task GetProdustListTest()
        {
            var sut = new GetAllProductsHandler(_context);

            var result = await sut.Handle(new GetAllProductsQuery(), CancellationToken.None);
            foreach (var product in result)
            {
                product.Should().BeOfType<ProductViewModel>();
            }

            result.Count.Should().Be(2);
        }
    }
}
