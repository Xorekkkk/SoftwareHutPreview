using System;

namespace SoftwareHutPreview.Application.Infrastructure.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, object key, string message)
            : base($"Usunięcie produktu\"{name}\" ({key}) nie powiodło się. {message}")
        {
        }
    }
}
