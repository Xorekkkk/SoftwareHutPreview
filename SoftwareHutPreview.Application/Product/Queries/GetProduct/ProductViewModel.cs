namespace SoftwareHutPreview.Application.Product.Queries.GetProduct
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}