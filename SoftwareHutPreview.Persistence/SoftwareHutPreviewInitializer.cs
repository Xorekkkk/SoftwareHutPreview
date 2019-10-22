using System.Linq;
using SoftwareHutPreview.Domain.Entities;

namespace SoftwareHutPreview.Persistence
{
    public class SoftwareHutPreviewInitializer
    {
        public static void Initialize(SoftwareHutPreviewDbContext context)
        {
            var initializer = new SoftwareHutPreviewInitializer();
            initializer.SeedData(context);
        }

        private void SeedData(SoftwareHutPreviewDbContext context)
        {
            context.Database.EnsureCreated();

            SeedCategoryType(context);
            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }
            if (!context.ProductTypes.Any())
            {
                SeedCategoryType(context);
            }
            if (!context.Products.Any())
            {
                SeedProducts(context);
            }
        
        }

        private void SeedCategoryType(SoftwareHutPreviewDbContext context)
        {
            context.ProductTypes.AddRange(new ProductType[]
            {
                new ProductType(){Name = "CPUs"},
                new ProductType(){Name = "Graphics Cards"},
                new ProductType(){Name = "Motherboards"},
                new ProductType(){Name = "Memory"}
            });
            context.SaveChanges();
        }

        private void SeedCategories(SoftwareHutPreviewDbContext context)
        {
            context.Categories.AddRange(new Category[]
            {
                new Category(){Name = "CPUs"}, 
                new Category(){Name = "Graphics Cards"}, 
                new Category(){Name = "Motherboards"}, 
                new Category(){Name = "Memory"} 
            });
            context.SaveChanges();
        }

        private void SeedProducts(SoftwareHutPreviewDbContext context)
        {
            var cpus = context.Categories.SingleOrDefault(x => x.Name == "CPUs");
            var memory = context.Categories.SingleOrDefault(x => x.Name == "Memory");
            var productType = context.ProductTypes.SingleOrDefault(x => x.Name == "CPUs");
            context.Products.AddRange(new Product[]
            {
                new Product(){Name = "Ryzen 4600fx", Description = "Procesor nowej generacji od Amd.", Category = cpus, Price = 1900, ProductType = productType}, 
                new Product(){Name = "Intel i7-9900k", Description = "Procesor 9 już generacji od intela.",Category = cpus,Price = 1400, ProductType = productType}, 
                new Product(){Name = "Patriot DDR4 3000 MHz", Description = "Super wydajny",Category = memory, Price = 400, ProductType = productType},
                new Product(){Name = "Patriot DDR4 3300 MHz", Description = "Jeden z bestsellerów tego roku.",Category = memory, Price = 200, ProductType = productType}
            });
            context.SaveChanges();
        }
    }
}
