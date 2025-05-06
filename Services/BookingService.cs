using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Services.Interfaces;

namespace HotelBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRoomService _roomService;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;

        public BookingService(
            IRoomService roomService,
            IPaymentService paymentService,
            IEmailService emailService)
        {
            _roomService = roomService;
            _paymentService = paymentService;
            _emailService = emailService;
        }

        public async Task<BookingDTO> CreateBookingAsync(BookingDTO booking)
        {
            var room = await _roomService.GetRoomByIdAsync(booking.RoomId);
            if (!room.IsAvailable)
            {
                throw new InvalidOperationException("Room is not available");
            }

            var payment = await _paymentService.ProcessPaymentAsync(booking.TotalAmount);
            if (payment.Status == PaymentStatus.Completed)
            {
                await _emailService.SendBookingConfirmationAsync(booking);
            }

            return booking;
        }

        public async Task<IEnumerable<BookingDTO>> GetUserBookingsAsync(int userId)
        {
            var bookings = await GetBookingsByUserIdAsync(userId);
            foreach (var booking in bookings)
            {
                var room = await _roomService.GetRoomByIdAsync(booking.RoomId);
                booking.TotalAmount = CalculateTotalAmount(room.PricePerNight, booking.CheckInDate, booking.CheckOutDate);
            }
            return bookings;
        }

        public async Task<bool> CancelBookingAsync(int bookingId, int userId)
        {
            var booking = await GetBookingByIdAsync(bookingId);
            if (booking.PaymentStatus == PaymentStatus.Completed)
            {
                await _paymentService.RefundPaymentAsync(bookingId);
                await _emailService.SendCancellationEmailAsync(booking);
            }
            return true;
        }
    }
} 