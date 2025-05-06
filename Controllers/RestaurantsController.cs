using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models.DTOs;
using HotelBookingAPI.Services.Interfaces;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IBookingService _bookingService;

        public RestaurantsController(
            IRestaurantService restaurantService,
            IBookingService bookingService)
        {
            _restaurantService = restaurantService;
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();
            return restaurant;
        }

        [HttpGet("{id}/menu")]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetRestaurantMenu(int id)
        {
            var menu = await _restaurantService.GetRestaurantMenuAsync(id);
            return Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> CreateRestaurant(RestaurantDTO restaurantDto)
        {
            var restaurant = await _restaurantService.CreateRestaurantAsync(restaurantDto);
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantDTO restaurantDto)
        {
            var restaurant = await _restaurantService.UpdateRestaurantAsync(id, restaurantDto);
            if (restaurant == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var result = await _restaurantService.DeleteRestaurantAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}