
using ApplicationService.DTOs;
using Data.Entities;

namespace ApplicationService.implementations.TelegramUserManagement
{
    public interface ITelegramUserManagementService
    {
        Task<List<TelegramUserEntity>> GetAllTelegramUsersAsync();
        Task<bool> UpdateUserStatusAsync(int id, Status status);
        Task<TelegramUserDto> GetDataForTelegramUserAsync(long userId);
    }
}
