

using Data.Entities;

namespace ApplicationService.implementations.TelegramMessagesManagement
{
    public interface ITelegramMessagesManagementService
    {
        Task<List<TelegramMessageEntity>> GetAllTelegramMessagesAsync();
        Task<List<TelegramMessageEntity>> GetTelegramMessagesByUserIdAsync(long userId);
    }
}
