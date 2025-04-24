using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;
using YourNamespace.Models;

public class RoomService : IRoomService
{
    private readonly ApplicationDbContext _context;

    public RoomService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> GetRoomByIdAsync(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<Room> CreateRoomAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Room> UpdateRoomAsync(int id, Room room)
    {
        if (id != room.Id)
            return null;

        _context.Entry(room).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return room;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await RoomExists(id))
                return null;
            throw;
        }
    }

    public async Task<bool> DeleteRoomAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
            return false;

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut)
    {
        return await _context.Rooms
            .Where(r => !_context.Bookings
                .Any(b => b.RoomId == r.Id &&
                         ((checkIn >= b.CheckInDate && checkIn < b.CheckOutDate) ||
                          (checkOut > b.CheckInDate && checkOut <= b.CheckOutDate))))
            .ToListAsync();
    }

    private async Task<bool> RoomExists(int id)
    {
        return await _context.Rooms.AnyAsync(e => e.Id == id);
    }
} 