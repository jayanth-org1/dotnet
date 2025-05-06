using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Services.Interfaces;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public BookingsController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> CreateBooking(BookingDTO bookingDto)
        {
            try
            {
                var room = await _roomService.GetRoomByIdAsync(bookingDto.RoomId);
                if (room == null)
                {
                    return NotFound("Room not found");
                }

                var booking = await _bookingService.CreateBookingAsync(bookingDto);
                return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetUserBookings(int userId)
        {
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(bookings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var userId = int.Parse(User.Identity.Name); // In real app, get from token
            var result = await _bookingService.CancelBookingAsync(id, userId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}