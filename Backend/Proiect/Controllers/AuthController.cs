using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AttributeRouting;
using Proiect.BLL.Interfaces;
using Proiect.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.WebApi;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
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
