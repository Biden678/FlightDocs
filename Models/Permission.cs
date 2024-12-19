using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class Permission
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public string function { get; set; } = string.Empty;
        [JsonIgnore]
        public List<DocumentType>? DocumentType { get; set; }

        public List<Group> ? Group { get; set; }
    }
}
