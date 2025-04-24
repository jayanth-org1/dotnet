using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> CreateRestaurant(Restaurant restaurant)
        {
            var createdRestaurant = await _restaurantService.CreateRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = createdRestaurant.Id }, createdRestaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            var updatedRestaurant = await _restaurantService.UpdateRestaurantAsync(id, restaurant);
            if (updatedRestaurant == null)
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