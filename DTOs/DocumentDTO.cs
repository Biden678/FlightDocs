namespace FlightDocs.DTOs
{
    public class DocumentDTO
    {
        public string Name { get; set; } = string.Empty;
        public Guid TypeId { get; set; }
        public string flightNo { get; set; } = string.Empty;
        public string updatedBy { get; set; } = string.Empty;
        public DateTime updatedAt { get; set; }
    }
}
