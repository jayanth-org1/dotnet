namespace HotelBookingAPI.Models.DTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int Capacity { get; set; }
        public bool IsOpen { get; set; }
        public List<MenuItemDTO> MenuItems { get; set; }
    }

    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
} 