using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Domain.Entities;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Test.Infrastructure
{
    public class SoftwareHutPreviewContextFactory
    {
        public static SoftwareHutPreviewDbContext Create()
        {
            var options = new DbContextOptionsBuilder<SoftwareHutPreviewDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new SoftwareHutPreviewDbContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public static void Destroy(SoftwareHutPreviewDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

    }
}
