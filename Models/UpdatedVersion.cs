using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class UpdatedVersion
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Version { get; set; }
        public Guid groupId { get; set; }
        public DateTime updatedAt { get; set; }
        [JsonIgnore]
        public Document? Document { get; set; }
    }
}
