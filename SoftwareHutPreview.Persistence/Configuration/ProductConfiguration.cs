using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Domain.Entities;

namespace SoftwareHutPreview.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(60);
            builder.HasOne(f => f.Category)
                .WithMany(t => t.Products);
        }
    }
}
