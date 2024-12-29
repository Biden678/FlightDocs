using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO.Compression;
namespace FlightDocs.Services
{
    public class DocumentService : IDocument
    {
        private readonly DB _db;
        private readonly string _uploadFolder;
        public DocumentService(DB db)
        {
            _db = db;
            _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }

        }



        public async Task<Document> addDocument(DocumentDTO dto)
        {
            if (dto.Name == null || dto.Name.Length == 0)
            {
                throw new ArgumentException("File is required.");
            }

            // Lấy tên file
            var fileName = Path.GetFileName(dto.Name.FileName);

            // Đường dẫn lưu tệp
            var filePath = Path.Combine(_uploadFolder, fileName);

            // Lưu tệp vào thư mục
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Name.CopyToAsync(stream);
            }

            // Tạo đối tượng Document
            var document = new Document
            {
                Id = Guid.NewGuid(),
                Name = fileName,
                TypeId = dto.TypeId,
                flightNo = dto.flightNo
            };

            // Lưu đối tượng Document trước
            await _db.Documents.AddAsync(document);
            await _db.SaveChangesAsync(); 

            // Tạo đối tượng DocumentDetail
            var newDetail = new DocumentDetail
            {
                Id = Guid.NewGuid(),
                DocId = document.Id, // Sử dụng Id đã được lưu
                updatedBy = dto.updatedBy,
                updatedAt = DateTime.UtcNow,
                status = 0,
                version = 1.0,
            };

            // Lưu DocumentDetail
            await _db.DocumentDetails.AddAsync(newDetail);
            await _db.SaveChangesAsync();

            return document;
        }
        public async Task<FileResult> DownloadDocument(Guid documentId)
        {
            // Tìm Document dựa vào Id
            var document = await _db.Documents.FindAsync(documentId);
            if (document == null)
            {
                throw new FileNotFoundException("Document not found.");
            }

            var filePath = Path.Combine(_uploadFolder, document.Name);
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found on server.");
            }

            // Tạo tệp ZIP trong bộ nhớ
            using var memoryStream = new MemoryStream();
            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                // Thêm file vào ZIP
                var entry = zipArchive.CreateEntry(document.Name, CompressionLevel.Fastest);
                using var originalFileStream = new FileStream(filePath, FileMode.Open);
                using var zipEntryStream = entry.Open();
                await originalFileStream.CopyToAsync(zipEntryStream);
            }

            memoryStream.Position = 0; // Đặt lại vị trí đầu stream

            // Trả ZIP về client
            var zipFileName = $"{Path.GetFileNameWithoutExtension(document.Name)}.zip";
            var contentType = "application/zip";
            return new FileContentResult(memoryStream.ToArray(), contentType)
            {
                FileDownloadName = zipFileName
            };
        }


        //
        public async Task<DocumentType> addType(DocumentType type)
        {
            type.Id = Guid.NewGuid();
            await _db.DocumentTypes.AddAsync(type);
            await _db.SaveChangesAsync();
            return type;
        }

        public async Task<DocumentType> addTypePermission(PermissionTypeDTO dto)
        {
            var dtype = await _db.DocumentTypes
                 .Where(t => t.Id.ToString().ToLower() == dto.typeId.ToString().ToLower())
                 .Include(p => p.Permission)
                 .FirstOrDefaultAsync();
            if (dtype == null)
                return null;

            var permission = await _db.Permissions.FindAsync(dto.permissionId);
            if (permission == null)
                return null;
            dtype?.Permission?.Add(permission);
            await _db.SaveChangesAsync();
            return dtype;

        }

        public async Task<DocumentDetailDTO> getDocumentDetail(Guid documentId)
        {
            var document = await _db.Documents.FindAsync(documentId);
            if (document==null) { throw new KeyNotFoundException($"DocumentDetail for Document ID {documentId} not found."); }

              var documentDetail = await _db.DocumentDetails
            .FirstOrDefaultAsync(d => d.DocId == documentId);

            return new DocumentDetailDTO
            {
                DocumentId = document.Id,
                DocumentName = document.Name,
                FlightNo = document.flightNo,
                UpdatedBy = documentDetail.updatedBy,
                UpdatedAt = documentDetail.updatedAt,
                Status = documentDetail.status,
                Version = documentDetail.version
            };
        }

        public async Task<Document> updateDocument(DocumentUpdateDTO dto)
        {
          

            // Tìm tài liệu cần cập nhật
            var document = await _db.Documents.FindAsync(dto.DocumentId);
            if (document == null)
            {
                throw new ArgumentException("Document not found.");
            }
            var documentDetail = await _db.DocumentDetails.FirstOrDefaultAsync(s => s.DocId == document.Id);
            if (documentDetail?.status == 1) {
                throw new ArgumentException("The document has already been confirmed and can no longer be modified.");
            }

            //
            var documentType = await _db.DocumentTypes
            .Include(dt => dt.Permission) // Bao gồm cả danh sách quyền liên kết
            .Where(dt => dt.Document.Any(d => d.Id ==document.Id))
            .FirstOrDefaultAsync();

            if (documentType == null)
            {
                throw new ArgumentException("Document type not found.");
            }
            //
            // Lấy danh sách permission liên kết với DocumentType
            var permissions = documentType.Permission;

            if (permissions == null || !permissions.Any())
            {
                throw new UnauthorizedAccessException("No permissions found for this document type.");
            }

            // Kiểm tra groupId của user với các permissions
            var userPermission = permissions
                .Where(p => p.GroupId == dto.GroupId)
                .FirstOrDefault();

            //if (userPermission == null || string.IsNullOrEmpty(userPermission.function))
            //{
            //    throw new UnauthorizedAccessException("User does not have permission for this document type.");
            //}

            // Kiểm tra function
            if (!userPermission.function.Contains("Modify", StringComparison.OrdinalIgnoreCase)
                || !userPermission.function.Contains("Approval", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("User does not have modify permission for this document.");
            }

            //
            if (dto.Name != null)
            {
                
                var oldFilePath = Path.Combine(_uploadFolder, document.Name);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }

                //new file
                var fileName = Path.GetFileName(dto.Name.FileName);
                var filePath = Path.Combine(_uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Name.CopyToAsync(stream);
                }

                // Cập nhật tên file mới trong database
                document.Name = fileName;
                    // Tăng version
                    documentDetail.version = Math.Round(documentDetail.version + 0.1, 1);
                    documentDetail.updatedAt = DateTime.UtcNow;
                    // Cập nhật DocumentDetail trong database
                    _db.DocumentDetails.Update(documentDetail);

                var updatedVersion = new UpdatedVersion
                {
                    Id = Guid.NewGuid(),
                    DocumentId = document.Id,
                    Version = documentDetail.version,
                    updatedAt = DateTime.UtcNow,
                    groupId = dto.GroupId,
                    Name = document.Name
                };

                await _db.UpdatedVersions.AddAsync(updatedVersion);

                // Lưu tài liệu đã cập nhật vào database
                _db.Documents.Update(document);
                await _db.SaveChangesAsync();
            }

            return document;
        }

        public async Task<DocumentDetail> documentApproval(ApprovalDTO dto)
        {
            var documentDetail = await _db.DocumentDetails.FirstOrDefaultAsync(s => s.DocId == dto.DocumentId);
            if (documentDetail == null)
            {
                throw new ArgumentException("Document not found.");
            }
            if (documentDetail.status != 0)
            {
                throw new ArgumentException("Document has already been confirmed");
            }

            var documentType = await _db.DocumentTypes
.Include(dt => dt.Permission) // Bao gồm cả danh sách quyền liên kết
.Where(dt => dt.Document.Any(d => d.Id == dto.DocumentId))
.FirstOrDefaultAsync();

            if (documentType == null)
            {
                throw new ArgumentException("Document type not found.");
            }
            //
            // Lấy danh sách permission liên kết với DocumentType
            var permissions = documentType.Permission;

            if (permissions == null || !permissions.Any())
            {
                throw new UnauthorizedAccessException("No permissions found for this document type.");
            }

            // Kiểm tra groupId của user với các permissions
            var userPermission = permissions
                .Where(p => p.GroupId == dto.GroupId)
                .FirstOrDefault();

            // Kiểm tra function
            if (!userPermission.function.Contains("Approval", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("User does not have modify permission for this document.");
            }

            documentDetail.status = 1;
            _db.DocumentDetails.Update(documentDetail);
            await _db.SaveChangesAsync();
            return documentDetail;
        }

        public async Task<List<Document>> getDocumentByAccount(Guid accountId, DateTime? startDate, DateTime? endDate)
        {
            // Lấy danh sách các chuyến bay mà accountId được phân công
            var flightNos = await _db.Flights
                .Where(f => f.Account.Any(a => a.Id == accountId))  // Lọc theo accountId
                .Select(f => f.flightNo)  // Lấy flightNo của các chuyến bay
                .ToListAsync();

            if (flightNos == null || flightNos.Count == 0)
            {
                throw new ArgumentException("No flights found for the account");
            }

            // Lọc tài liệu theo flightNo từ danh sách flightNos và lọc theo ngày (startDate và endDate)
            var documentsQuery = _db.Documents
                .Where(d => flightNos.Contains(d.flightNo));  // So sánh flightNo với danh sách flightNos

            // Lọc thêm theo ngày nếu có
            if (startDate.HasValue)
            {
               
                documentsQuery = documentsQuery.Where(d =>
                    d.Flight.departureDate.Date >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                
                documentsQuery = documentsQuery.Where(d =>
                    d.Flight.departureDate.Date <= endDate.Value.Date);
            }

 
            var documents = await documentsQuery.ToListAsync();

            if (documents == null || documents.Count == 0)
            {
                throw new ArgumentException("No documents found for the assigned flights");
            }

            return documents;  
        }
    }
}
