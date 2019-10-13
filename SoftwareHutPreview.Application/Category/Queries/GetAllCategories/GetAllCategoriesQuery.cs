using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SoftwareHutPreview.Application.Product.ViewModels;

namespace SoftwareHutPreview.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IList<CategoryViewModel>>
    {
    }
}
