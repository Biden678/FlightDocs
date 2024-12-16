using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class DocumentType
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Type { get; set; } = string.Empty;
 
        public List<DocumentTypePermission>? DocumentTypePermission { get; set; }
        public List<Document>? Document { get; set; }
    }
}
