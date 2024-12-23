using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid TypeId { get; set; }

        public string flightNo { get; set; } = string.Empty;
        public DocumentType ? Type { get; set; }
        public DocumentDetail? DocumentDetail { get; set; }

        public Flight ? Flight { get; set; }
    }
}
