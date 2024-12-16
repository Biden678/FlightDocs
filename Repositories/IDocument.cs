using FlightDocs.DTOs;
using FlightDocs.Models;

namespace FlightDocs.Repositories
{
    public interface IDocument
    {
        Task<DocumentType> AddType(DocumentType type, List<Guid> permissionIds);
        //
    }
}
