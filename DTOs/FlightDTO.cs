using System.ComponentModel.DataAnnotations;

namespace FlightDocs.DTOs
{
    public class FlightDTO
    {
        [Key]
        public string flightNo { get; set; } = string.Empty;
        public string pointOfLoading { get; set; } = string.Empty;
        public string pointOfUnloading { get; set; } = string.Empty;
        public DateTime departureDate { get; set; } 
    }
}
