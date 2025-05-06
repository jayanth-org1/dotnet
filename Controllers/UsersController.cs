using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Services.Interfaces;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly IEmailService _emailService;

        public UsersController(
            IUserService userService,
            IBookingService bookingService,
            IEmailService emailService)
        {
            _userService = userService;
            _bookingService = bookingService;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            var user = await _userService.RegisterUserAsync(registerDto);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            return Ok(new { token });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet("{id}/bookings")]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetUserBookings(int id)
        {
            var bookings = await _userService.GetUserBookingHistoryAsync(id);
            return Ok(bookings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDto)
        {
            var user = await _userService.UpdateUserAsync(id, userDto);
            if (user == null)
                return NotFound();
            return NoContent();
        }
    }
}