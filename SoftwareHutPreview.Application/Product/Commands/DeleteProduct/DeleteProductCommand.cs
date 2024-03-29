﻿using MediatR;

namespace SoftwareHutPreview.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
