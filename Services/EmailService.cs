using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendBookingConfirmationAsync(BookingDTO booking)
        {
            // Email sending logic
            await Task.CompletedTask;
        }

        public async Task SendCancellationEmailAsync(BookingDTO booking)
        {
            // Cancellation email logic
            await Task.CompletedTask;
        }
    }
} 