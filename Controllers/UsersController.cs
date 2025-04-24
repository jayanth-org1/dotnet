using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            // Logic for user registration
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            // Logic for user login
            return Ok("User logged in successfully");
        }
    }
}