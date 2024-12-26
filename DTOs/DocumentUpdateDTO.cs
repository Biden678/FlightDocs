namespace FlightDocs.DTOs
{
    public class DocumentUpdateDTO
    {
        public IFormFile? Name { get; set; }
        public Guid DocumentId { get; set; }
        //public Guid TypeId { get; set; }

    }
}
