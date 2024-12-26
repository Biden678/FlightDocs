using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid TypeId { get; set; }

        public string flightNo { get; set; } = string.Empty;
        [JsonIgnore]
        public DocumentType? Type { get; set; }
        [JsonIgnore]
        public DocumentDetail? DocumentDetail { get; set; }
        [JsonIgnore]
        public Flight? Flight { get; set; }
    }
}
