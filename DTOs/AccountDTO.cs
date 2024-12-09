using System.ComponentModel.DataAnnotations;

namespace FlightDocs.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[a-zA-Z0-9]{1,25}@vietjetair\\.com$", ErrorMessage = "Email must have domain @vietjetair.com")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public string Phone { get; set; }  = string.Empty;
        [Required]
        public Guid groupId { get; set; }
    }
}
