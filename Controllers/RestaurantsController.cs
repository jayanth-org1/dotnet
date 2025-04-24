using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            // Logic to list all restaurants
            return Ok("List of restaurants");
        }

        [HttpPost]
        public IActionResult AddRestaurant()
        {
            // Logic to add a new restaurant
            return Ok("Restaurant added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id)
        {
            // Logic to update a restaurant
            return Ok("Restaurant updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            // Logic to delete a restaurant
            return Ok("Restaurant deleted successfully");
        }
    }
}