using YourNamespace.Models;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task<Payment> GetPaymentByIdAsync(int id);
    Task<Payment> CreatePaymentAsync(Payment payment);
    Task<Payment> UpdatePaymentAsync(int id, Payment payment);
    Task<bool> DeletePaymentAsync(int id);
    Task<IEnumerable<Payment>> GetBookingPaymentsAsync(int bookingId);
} 