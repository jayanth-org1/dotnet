using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerService CustomerService;  // Public field instead of private readonly

        public CustomersController()  // Not using dependency injection
        {
            CustomerService = new CustomerService(new ApplicationDbContext());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await CustomerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = CustomerService.GetCustomerByIdAsync(id).GetAwaiter().GetResult();
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("{id}/bookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetCustomerBookings(int id)
        {
            var bookings = await CustomerService.GetCustomerBookingsAsync(id);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var createdCustomer = await CustomerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var updatedCustomer = await CustomerService.UpdateCustomerAsync(id, customer);
            if (updatedCustomer == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await CustomerService.DeleteCustomerAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPost("notify")]
        public async void NotifyCustomer(int id)
        {
            await CustomerService.SendNotificationAsync(id);
        }
    }
} 