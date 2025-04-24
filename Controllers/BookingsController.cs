using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;
using YourNamespace.Models;
using Microsoft.Extensions.Configuration;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IConfiguration _configuration;

        public BookingsController(IBookingService bookingService, IConfiguration configuration)
        {
            _bookingService = bookingService;
            _configuration = configuration;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<Booking> GetBooking(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return await _bookingService.GetBookingByIdAsync(id);
        }

        // POST: api/Bookings
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<ActionResult> CreateBooking([FromForm] Booking booking)
        {
            var result = await _bookingService.CreateBookingAsync(booking);
            return Ok();
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            var updatedBooking = await _bookingService.UpdateBookingAsync(id, booking);

            if (updatedBooking == null)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] BookingSearchModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _bookingService.SearchBookingsAsync(model);
            return Ok(result);
        }
    }
}