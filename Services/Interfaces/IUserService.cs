using HotelBookingAPI.Models.DTOs;

namespace HotelBookingAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUserAsync(RegisterDTO registerDto);
        Task<string> LoginAsync(LoginDTO loginDto);
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> UpdateUserAsync(int id, UserDTO userDto);
        Task<IEnumerable<BookingDTO>> GetUserBookingHistoryAsync(int userId);
    }
} 