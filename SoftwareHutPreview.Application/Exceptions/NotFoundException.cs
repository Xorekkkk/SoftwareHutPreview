using System;

namespace SoftwareHutPreview.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) 
            : base($"\"{name}\" ({key} Nie udało się znależć produktu.)")
        {
        }
    }
}
