using BlogApp.Business.DTOs.UserDTO;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterDto registerDto)
        {
            await _service.Register(registerDto);
            return Ok();
        }
    }
}
