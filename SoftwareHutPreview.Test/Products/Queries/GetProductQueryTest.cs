using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using SoftwareHutPreview.Application.Product.Queries.GetProduct;
using SoftwareHutPreview.Test.Infrastructure;
using Xunit;

namespace SoftwareHutPreview.Test.Products.Queries
{
    public class GetProductQueryTest : CommandTestBase
    {

        [Fact]
        public async Task GetProductDetail()
        {
            var sut = new GetProductHandler(_context);

            var result = await sut.Handle(new GetProductQuery(){Id = 2}, CancellationToken.None);

            result.Name.Should().Contain("Intel");
        }
    }
}
