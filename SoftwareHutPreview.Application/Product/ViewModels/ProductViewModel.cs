﻿namespace SoftwareHutPreview.Application.Product.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryViewModel Category { get; set; }
        public ProductTypeViewModel ProductType { get; set; }
    }
}