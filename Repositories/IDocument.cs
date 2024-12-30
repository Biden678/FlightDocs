using FlightDocs.DTOs;
using FlightDocs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Repositories
{
    public interface IDocument
    {
        Task<DocumentType> addType(TypeDTO dto);
        //
        Task<DocumentType> addTypePermission(PermissionTypeDTO dto);

        Task<Document> addDocument(DocumentDTO dto);

        Task<FileResult> DownloadDocument(Guid documentId);

        Task<FileResult> DownloadDocuments(List<Guid> documentId);

        Task<DocumentDetailDTO> getDocumentDetail(Guid documentId);

        Task<Document> updateDocument(DocumentUpdateDTO dto);

        Task<DocumentDetail> documentApproval(ApprovalDTO dto);

        Task<List<Document>> getDocumentByAccount(Guid accountId, DateTime? startDate, DateTime? endDate);

        Task<Document> getVersionDocument(Guid documentId);
    }
}
