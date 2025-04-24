using YourNamespace.Models;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetAllRoomsAsync();
    Task<Room> GetRoomByIdAsync(int id);
    Task<Room> CreateRoomAsync(Room room);
    Task<Room> UpdateRoomAsync(int id, Room room);
    Task<bool> DeleteRoomAsync(int id);
    Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
} 