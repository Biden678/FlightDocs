namespace FlightDocs.DTOs
{
    public class DocumentDTO
    {
        public IFormFile ? Name { get; set; }
        public Guid TypeId { get; set; }
        public string flightNo { get; set; } = string.Empty;
        public string updatedBy { get; set; } = string.Empty;
    
    }
}
