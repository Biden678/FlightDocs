using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid TypeId { get; set; }
        public DocumentType ? Type { get; set; }
        public List<DocumentDetail>? Detail { get; set; }
        public Flight ? Flight { get; set; }
    }
}
