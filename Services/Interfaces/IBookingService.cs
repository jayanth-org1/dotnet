using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDTO> CreateBookingAsync(BookingDTO booking);
        Task<IEnumerable<BookingDTO>> GetUserBookingsAsync(int userId);
        Task<bool> CancelBookingAsync(int bookingId, int userId);
    }
} 