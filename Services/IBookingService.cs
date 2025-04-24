using YourNamespace.Models;

public interface IBookingService
{
    Task<IEnumerable<Booking>> GetAllBookingsAsync();
    Task<Booking> GetBookingByIdAsync(int id);
    Task<Booking> CreateBookingAsync(Booking booking);
    Task<Booking> UpdateBookingAsync(int id, Booking booking);
    Task<bool> DeleteBookingAsync(int id);
} 