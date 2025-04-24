using YourNamespace.Models;

public interface IRestaurantService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    Task<Restaurant> GetRestaurantByIdAsync(int id);
    Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant);
    Task<Restaurant> UpdateRestaurantAsync(int id, Restaurant restaurant);
    Task<bool> DeleteRestaurantAsync(int id);
} 