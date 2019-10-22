using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareHutPreview.Domain.Entities
{
    public class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
