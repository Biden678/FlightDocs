using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class DocumentDetail
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string updatedBy { get; set; } = string.Empty;
        public string updatedAt { get; set; } = string.Empty;
        public int version { get; set; } = 1;
        public int status { get; set; } = 0;
        public Guid documentId { get; set; }
        public Document Document { get; set; } = new Document(); 
        public List<Flight>? Flight { get; set; }
    }
}
