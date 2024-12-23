using FlightDocs.DTOs;
using FlightDocs.Models;

namespace FlightDocs.Repositories
{
    public interface IDocument
    {
        Task<DocumentType> AddType(DocumentType type);
        //
        Task<DocumentType> addTypePermission(PermissionTypeDTO dto);

        Task<Document> addDocument(DocumentDTO dto);
    }
}
