namespace HotelBookingAPI.Models.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }

    public enum RoomType
    {
        Single,
        Double,
        Suite,
        Deluxe
    }
} 