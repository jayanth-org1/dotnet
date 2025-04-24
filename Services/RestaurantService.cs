using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;
using YourNamespace.Models;

public class RestaurantService : IRestaurantService
{
    private readonly ApplicationDbContext _context;

    public RestaurantService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task<Restaurant> GetRestaurantByIdAsync(int id)
    {
        return await _context.Restaurants.FindAsync(id);
    }

    public async Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
        return restaurant;
    }

    public async Task<Restaurant> UpdateRestaurantAsync(int id, Restaurant restaurant)
    {
        if (id != restaurant.Id)
            return null;

        _context.Entry(restaurant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return restaurant;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await RestaurantExists(id))
                return null;
            throw;
        }
    }

    public async Task<bool> DeleteRestaurantAsync(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
            return false;

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<bool> RestaurantExists(int id)
    {
        return await _context.Restaurants.AnyAsync(e => e.Id == id);
    }
} 