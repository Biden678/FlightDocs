namespace FlightDocs.DTOs
{
    public class DocumentTypeDTO
    {
        public string Type { get; set; } = string.Empty;

        public List<Guid> PermissionIds { get; set; } = new List<Guid>();
    }
}
