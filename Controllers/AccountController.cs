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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _asv;
        public AccountController(IAccount accountService) 
        { 
            _asv = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> addAccount(AccountDTO account)
        {
            try
            {
                if (ModelState.IsValid)
                {
               var  createdAccount =   await _asv.AddAccount(account);
                    var response = new CustomStatusCode<Account>(201, "create account sucessfully", createdAccount, null);
                    return Ok(response);
                }
                else {

                    var response = new CustomStatusCode<Account>(400, "Unable to create account", null, null);
                    return BadRequest(response);
                }
                
            }
            catch (Exception ex) {
                return StatusCode(500, new CustomStatusCode<Account>()
                {
                    Message = "An occurred while retrieving the model",
                    Error = ex.Message
                });
            }

        }
        [HttpGet]
        public async Task<IActionResult> getAccounts() {
            var acc = await _asv.getAllAcount();
            if (acc.Count() > 0)
            {
                var response = new CustomStatusCode<IEnumerable<Account>>(200, "get accounts successfully", acc, null);
                return Ok(response);
            }
            else {
                var response = new CustomStatusCode<IEnumerable<Account>>(404, "not found accounts", acc, null);
                return NotFound(response);
            }
        }
        [HttpPost("Authenticated")]

        public IActionResult Authenticate([FromBody] LoginDTO loginDTO)
        {
            var token = _asv.Login(loginDTO); 

            if (!string.IsNullOrEmpty(token)) 
            {
                return Ok(new { Token = token }); 
            }
            else
            {
                return Unauthorized(new { Message = "Invalid email or password" }); 
            }
        }



    }
}
