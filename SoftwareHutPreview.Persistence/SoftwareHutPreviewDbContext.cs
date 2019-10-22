using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Domain.Entities;

namespace SoftwareHutPreview.Persistence
{
    public class SoftwareHutPreviewDbContext : DbContext
    {
        public SoftwareHutPreviewDbContext(DbContextOptions<SoftwareHutPreviewDbContext> options) : base(options) { }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<ProductType> ProductTypes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoftwareHutPreviewDbContext).Assembly);
        } 
    }
}
