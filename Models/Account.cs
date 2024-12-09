using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Group ? Group { get; set; }
        public Guid groupId { get; set; }
    }
}
