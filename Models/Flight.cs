using System.ComponentModel.DataAnnotations;

namespace FlightDocs.Models
{
    public class Flight
    {
        [Key]
        public string flightNo { get; set; } = string.Empty;
        public string pointOfLoading { get; set; } = string.Empty;
        public string pointOfUnloading { get; set; } = string.Empty;
        public string departureDate { get; set; } = string.Empty;
        public List<Document>? Document { get; set; }
        public List<FlightAssignment>? FlightAssignment { get; set; }
    }
}
