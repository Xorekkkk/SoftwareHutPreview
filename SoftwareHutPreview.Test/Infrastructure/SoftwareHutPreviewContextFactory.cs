using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            context.Categories.Add(new Category { Id = 1, Name = "Cpus" });
            var cpus = context.Categories.SingleOrDefault();

            context.Products.AddRange(new[]{new Product() {Id=3, Name = "Ryzen 4600fx", Description = "Procesor nowej generacji od Amd.", Category = cpus, Price = 1900 },
                new Product() {Id=4, Name = "Intel i7-9900k", Description = "Procesor 9 już generacji od intela.", Category = cpus, Price = 1400 },
                new Product() {Id=5, Name = "Intel i5-9900k", Description = "Budzetowa wersja dla kazdego.", Category = cpus, Price = 1400 }
            });

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
