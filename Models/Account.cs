using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [JsonIgnore]
        public Group ? Group { get; set; }
        public Guid groupId { get; set; }
        public List<Flight>? Flight { get; set; }
    }
}
