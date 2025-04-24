using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateBooking()
        {
            // Logic to create a new booking
            return Ok("Booking created successfully");
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            // Logic to view all bookings
            return Ok("List of bookings");
        }

        [HttpDelete("{id}")]
        public IActionResult CancelBooking(int id)
        {
            // Logic to cancel a booking
            return Ok("Booking canceled successfully");
        }
    }
}