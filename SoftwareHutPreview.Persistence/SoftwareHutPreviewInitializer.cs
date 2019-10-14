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
            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }
            if (!context.Products.Any())
            {
                SeedProducts(context);
            }
        
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
            context.Products.AddRange(new Product[]
            {
                new Product(){Name = "Ryzen 4600fx", Description = "Procesor nowej generacji od Amd.", Category = cpus, Price = 1900}, 
                new Product(){Name = "Intel i7-9900k", Description = "Procesor 9 już generacji od intela.",Category = cpus,Price = 1400}, 
                new Product(){Name = "Patriot DDR4 3000 MHz", Description = "Super wydajny",Category = memory, Price = 400},
                new Product(){Name = "Patriot DDR4 3300 MHz", Description = "Jeden z bestsellerów tego roku.",Category = memory, Price = 200}
            });
            context.SaveChanges();
        }
    }
}
