namespace FlightDocs.DTOs
{
    public class DocumentDetailDTO
    {
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string FlightNo { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
        public double Version { get; set; }
    }
}
