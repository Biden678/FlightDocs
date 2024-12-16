using FlightDocs.Models;
using FlightDocs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Services
{
        public class DocumentService : IDocument
        {
            private readonly DB _db;

            public DocumentService(DB db)
            {
                _db = db;
            }
        public async Task<DocumentType> AddType(DocumentType type, List<Guid> permissionIds)
        {
            // Tạo mới DocumentType với Id mới
            //, List<Guid> permissionIds
            type.Id = Guid.NewGuid();
            await _db.DocumentTypes.AddAsync(type);

            // Kiểm tra xem permissionIds có ít nhất 2 phần tử không
            if (permissionIds.Count >= 2)
            {
                // Lấy 2 PermissionId từ permissionIds và tạo các bản ghi mới trong bảng DocumentTypePermission
                var documentTypePermissions = new List<DocumentTypePermission>
        {
            new DocumentTypePermission
            {
                Id = Guid.NewGuid(),
                DocumentTypeId = type.Id,
                PermissionId = permissionIds[0] // PermissionId đầu tiên
            },
            new DocumentTypePermission
            {
                Id = Guid.NewGuid(),
                DocumentTypeId = type.Id,
                PermissionId = permissionIds[1] // PermissionId thứ hai
            }
        };

                // Thêm các bản ghi vào bảng DocumentTypePermission
                await _db.TypePermissions.AddRangeAsync(documentTypePermissions);
            }
            else
            {
                throw new ArgumentException("At least two permission IDs are required.");
            }

            // Lưu các thay đổi vào DB
            await _db.SaveChangesAsync();

            return type;
        }


    }
}
