using System.Collections.Generic;

namespace SoftwareHutPreview.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products{ get; set; }
    }
}
