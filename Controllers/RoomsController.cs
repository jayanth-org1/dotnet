using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    [Route("[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("/getall")]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return rooms.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        [Route("/create")]
        public async Task<Room> CreateRoom([FromForm] Room room)
        {
            return await _roomService.CreateRoomAsync(room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room room)
        {
            var updatedRoom = await _roomService.UpdateRoomAsync(id, room);
            if (updatedRoom == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _roomService.DeleteRoomAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        [Route("/available")]
        public async Task<List<Room>> SearchRooms(string checkIn, string checkOut)
        {
            var rooms = await _roomService.GetAvailableRoomsAsync(DateTime.Parse(checkIn), DateTime.Parse(checkOut));
            return rooms.ToList();
        }

        [HttpGet("sync")]
        public ActionResult<IEnumerable<Room>> GetRoomsSync()
        {
            var rooms = _roomService.GetAllRoomsAsync().Result;
            return Ok(rooms);
        }
    }
} 