using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SoftwareHutPreview.Application.Product.ViewModels;

namespace SoftwareHutPreview.Application.ProductType.Queries
{
   public class GetAllProductTypeQuery : IRequest<IList<ProductTypeViewModel>>
    {
    }
}
