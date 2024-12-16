using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class FlightAssignment
    {
        [Key]
        public Guid Id { get; set; }
        public string flightNo { get; set; } = string.Empty;
        public Guid accountId { get; set; }
        public string groupName { get; set; } = string.Empty;
        public Flight Flight { get; set; } = new Flight();

        public Account Account { get; set; } = new Account();
    }
}
