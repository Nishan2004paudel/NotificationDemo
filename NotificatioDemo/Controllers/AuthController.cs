using Microsoft.AspNetCore.Mvc;
using NotificatioDemo.Data;
using NotificatioDemo.DTOs;

namespace NotificatioDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email && u.PasswordHash == dto.Password);

            if (user == null)
                return Unauthorized(new { Message = "Invalid Credentials" });

            return Ok(new UserDto
            {
                Id = user.Id,
                Username = user.Username
            });
        }
    }
}