using Microsoft.AspNetCore.Mvc;
using Proiect.BLL.Interfaces;
using Proiect.BLL.Models;
using System;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authManager.Register(registerModel);
            Console.Write("Result: ");
            Console.WriteLine(_authManager);
            return result ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authManager.Login(loginModel);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Failed to login");
        }
    }
}
