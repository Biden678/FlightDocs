using FlightDocs.DTOs;
using FlightDocs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Repositories
{
    public interface IDocument
    {
        Task<DocumentType> addType(DocumentType type);
        //
        Task<DocumentType> addTypePermission(PermissionTypeDTO dto);

        Task<Document> addDocument(DocumentDTO dto);

        Task<FileResult> DownloadDocument(Guid documentId);

        Task<DocumentDetailDTO> getDocumentDetail(Guid documentId);

        Task<Document> updateDocument(DocumentUpdateDTO dto);

        Task<DocumentDetail> documentApproval(ApprovalDTO dto);

        Task<List<Document>> getDocumentByAccount(Guid accountId, DateTime? startDate, DateTime? endDate);

    }
}
