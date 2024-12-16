using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class DocumentTypePermission
    {
        [Key] 
        public Guid Id { get; set; }
        public Guid DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; } = new DocumentType();
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = new Permission();
    }
}
