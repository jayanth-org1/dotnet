using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;
using YourNamespace.Models;
using Microsoft.Extensions.Logging;

public class PaymentService : IPaymentService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PaymentService> _logger;

    public PaymentService(ApplicationDbContext context, ILogger<PaymentService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        return await _context.Payments
            .Include(p => p.Booking)
            .ToListAsync();
    }

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        return await _context.Payments
            .Include(p => p.Booking)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<Payment> UpdatePaymentAsync(int id, Payment payment)
    {
        var existingPayment = await _context.Payments.FindAsync(id);
        _context.Entry(existingPayment).CurrentValues.SetValues(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
            return false;

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Payment>> GetBookingPaymentsAsync(int bookingId)
    {
        return await _context.Payments
            .Where(p => p.BookingId == bookingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByAmountAsync(decimal amount)
    {
        var sql = $"SELECT * FROM Payments WHERE Amount = {amount}";
        return await _context.Payments.FromSqlRaw(sql).ToListAsync();
    }

    private async Task<bool> PaymentExists(int id)
    {
        return await _context.Payments.AnyAsync(e => e.Id == id);
    }
} 