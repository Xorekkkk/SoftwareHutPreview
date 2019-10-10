using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Persistence.Infrastructure;

namespace SoftwareHutPreview.Persistence
{
    public class SoftwareHutPreviewDbContextFactory : DesignTimeDbContextFactoryBase<SoftwareHutPreviewDbContext>
    {
        protected override SoftwareHutPreviewDbContext CreateNewInstance(DbContextOptions<SoftwareHutPreviewDbContext> options)
        {
            return new SoftwareHutPreviewDbContext(options);
        }
    }
}
