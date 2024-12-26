using System.Text.Json.Serialization;

namespace FlightDocs.Models
{
        public class DocumentDetail
        {
            public Guid Id { get; set; }
            public Guid DocId { get; set; }

            public string updatedBy { get; set; } = string.Empty;

            public DateTime updatedAt { get; set; }
            public int status { get; set; }
            public double version { get; set; }
        [JsonIgnore]
            public Document? Document { get; set; }
        }
}
