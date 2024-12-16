using System.ComponentModel.DataAnnotations;

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

        public List<DocumentTypePermission>? DocumentTypePermission { get; set; }

        public List<Group> ? Group { get; set; }
    }
}
