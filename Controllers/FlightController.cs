using FlightDocs.DTOs;
using FlightDocs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlight _fsv;
        public FlightController(IFlight fsv) {
            _fsv = fsv;
        }

        [HttpPost("add-flight")]
        public async Task<IActionResult> Add(FlightDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _fsv.addFlight(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }
    }
}
