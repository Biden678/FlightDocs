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
                var result = await _dsv.AddType(request);
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
            //if (request == null)
            //{
            //    return BadRequest();
            //}

            //try
            //{
            //    var result = await _dsv.addTypePermission(request);
            //    return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Internal server error: {ex.Message}");

            //}
            var dtype = await _db.DocumentTypes
               .Where(t => t.Id.ToString().ToLower() == request.typeId.ToString().ToLower())
               .Include(p => p.Permission)
               .FirstOrDefaultAsync();
            if (dtype == null)
                return NotFound();

            var permission = await _db.Permissions.FindAsync(request.permissionId);
            if (permission == null)
                return NotFound();
            dtype?.Permission?.Add(permission);
            await _db.SaveChangesAsync();
            return Ok(dtype);
        }



    }
}
