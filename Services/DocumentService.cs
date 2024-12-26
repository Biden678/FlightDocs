using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                // Lưu tài liệu đã cập nhật vào database
                _db.Documents.Update(document);
                await _db.SaveChangesAsync();
            }

            return document;
        }
    }
}
