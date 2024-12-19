using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class DocumentTypePermission
    {
        [Key] 
        public Guid Id { get; set; }
        public Guid DocumentTypeId { get; set; }
        [JsonIgnore]
        public DocumentType DocumentType { get; set; } = new DocumentType();
        public Guid PermissionId { get; set; }
        [JsonIgnore]
        public Permission Permission { get; set; } = new Permission();
    }
}
