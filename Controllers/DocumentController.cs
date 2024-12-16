using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;
using FlightDocs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocument _dsv;
        public DocumentController(IDocument documentRepository)
        {
            _dsv = documentRepository;
        }
        [HttpPost("add-type")]
        public async Task<IActionResult> AddDocumentType([FromBody] DocumentTypeDTO request)
        {
            if (request == null || request.PermissionIds == null || request.PermissionIds.Count < 2)
            {
                return BadRequest("At least two permission IDs are required.");
            }

            try
            {
                // Tạo đối tượng DocumentType từ request
                var documentType = new DocumentType
                {
                    Type = request.Type // Set type từ request
                };

                // Gọi service để thêm DocumentType và permissions
                var result = await _dsv.AddType(documentType, request.PermissionIds);

                // Trả về kết quả với mã 201 (Created) và đối tượng DocumentType đã được tạo
                return CreatedAtAction(nameof(AddDocumentType), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, trả về lỗi 500 với thông báo lỗi
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
