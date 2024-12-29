using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
    public class Flight
    {
        [Key]
        public string flightNo { get; set; } = string.Empty;
        public string pointOfLoading { get; set; } = string.Empty;
        public string pointOfUnloading { get; set; } = string.Empty;
        public DateTime departureDate { get; set; }
        [JsonIgnore]

        public List<Document>? Document { get; set; }
        [JsonIgnore]
        public List<Account>? Account { get; set; }
    }
}
