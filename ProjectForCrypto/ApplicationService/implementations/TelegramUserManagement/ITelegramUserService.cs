
using ApplicationService.DTOs;
using Data.Entities;

namespace ApplicationService.implementations.TelegramUserManagement
{
    public interface ITelegramUserService
    {
        Task<List<TelegramUserEntity>> GetAllTelegramUsersAsync();
        Task<bool> UpdateUserStatusAsync(int id, Status status);
    }
}
