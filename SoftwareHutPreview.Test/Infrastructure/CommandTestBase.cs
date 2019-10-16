using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftwareHutPreview.Persistence;

namespace SoftwareHutPreview.Test.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly SoftwareHutPreviewDbContext _context;

        public CommandTestBase()
        {
            _context = SoftwareHutPreviewContextFactory.Create();
        }
        public void Dispose()
        {
            SoftwareHutPreviewContextFactory.Destroy(_context);
        }
    }
}
