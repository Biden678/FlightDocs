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



        public async Task<Document> addDocument(DocumentDTO dto)
        {
            var newDoc = new Document
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                TypeId = dto.TypeId,
                flightNo = dto.flightNo
            };
            await _db.Documents.AddAsync(newDoc);
            await _db.SaveChangesAsync();

            //if (newDoc != null)
            //{
            //    var newDetail = new DocumentDetail
            //    {
            //        Id = Guid.NewGuid(),
            //        DocId = newDoc.Id,
            //        updatedBy = dto.updatedBy,
            //        updatedAt = dto.updatedAt,
            //        status = 0,
            //        version = 1.0,
            //    };
            //    await _db.DocumentDetails.AddAsync(newDetail);
            //    await _db.SaveChangesAsync();
            //} else { return null; }
            return newDoc;
        }


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
