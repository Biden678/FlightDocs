using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Group 
    {
        [Key]
        [Required]
        public Guid Id { get; set; } 

        [Required]
        public string nameGroup { get; set; } = string.Empty;

        public List <Account> ? Accounts { get; set; }
    }
}
