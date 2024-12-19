using FlightDocs.DTOs;
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

  
        //public  async Task<DocumentTypePermission> addPermissison(PermissionTypeDTO dto)
        //{
        //    try
        //    {
          
        //        var typePermisison = new DocumentTypePermission
        //        {
        //            Id = Guid.NewGuid(),
        //            DocumentTypeId = dto.typeId,
        //            PermissionId = dto.permissionId
        //        };

        //        await _db.TypePermissions.AddAsync(typePermisison);
        //        await _db.SaveChangesAsync();
        //        return typePermisison;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log lỗi để xem nguyên nhân
        //        throw new Exception($"Error adding permission: {ex.Message}", ex);
        //    }
        //}

        public async Task<DocumentType> AddType(DocumentType type)
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
    }
}
