using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class DocumentType
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Type { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Permission> ? Permission { get; set; }
        public List<Document>? Document { get; set; }
    }
}
