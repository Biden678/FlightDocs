using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;
using FlightDocs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocument _dsv;
        private readonly DB _db;
        public DocumentController(IDocument documentRepository, DB db)
        {
            _dsv = documentRepository;
            _db = db;
        }
        [HttpPost("add-type")]
        public async Task<IActionResult> AddDocumentType(DocumentType request)
        {
            if (request == null )
            {
                return BadRequest();
            }

            try
            {
                var result = await _dsv.addType(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("type-addpermission")]
        public async Task<IActionResult> AddTypePermisison(PermissionTypeDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _dsv.addTypePermission(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
           
        }
        [HttpPost("add-doc")]
        public async Task<IActionResult> AddDocument([FromForm] DocumentDTO request) {

             if (request == null)
        {
            return BadRequest("Request or file is missing.");
        }
            try
            {
                var result = await _dsv.addDocument(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [HttpPut("update-doc")]
        public async Task<IActionResult> updateDocument([FromForm] DocumentUpdateDTO request)
        {

            if (request == null)
            {
                return BadRequest("Request or file is missing.");
            }
            try
            {
                var result = await _dsv.updateDocument(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadDocument(Guid id)
        {
            try
            {
                // Gọi service để xử lý tải file
                var fileResult = await _dsv.DownloadDocument(id);
                return fileResult; // Trả về file kết quả
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("DocumentDetail/{id}")]
        public async Task<IActionResult> GetDocumentDetail(Guid docId)
        {
            try
            {
                var detail = await _dsv.getDocumentDetail(docId);
                return Ok(detail);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Approval")]
        public async Task<IActionResult> ConfirmDocument(ApprovalDTO request)
        {
            try
            {
                var response = await _dsv.documentApproval(request);
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getDocumentByAccount")]
        public async Task<IActionResult> getByAccount(Guid request, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var response = await _dsv.getDocumentByAccount(request, startDate, endDate);
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
