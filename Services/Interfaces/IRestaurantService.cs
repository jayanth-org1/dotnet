using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync();
        Task<RestaurantDTO> GetRestaurantByIdAsync(int id);
        Task<RestaurantDTO> CreateRestaurantAsync(RestaurantDTO restaurant);
        Task<RestaurantDTO> UpdateRestaurantAsync(int id, RestaurantDTO restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<IEnumerable<MenuItemDTO>> GetRestaurantMenuAsync(int restaurantId);
    }
} 