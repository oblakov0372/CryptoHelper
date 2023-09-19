using ApplicationService.DTOs;
using Contracts;
using Data.Entities;

namespace ApplicationService.implementations.TelegramUserManagement
{
    public class TelegramUserService : ITelegramUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TelegramUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TelegramUserEntity>> GetAllTelegramUsersAsync()
        {
            var telegramUsers = await _unitOfWork.TelegramUsers.GetAllAsync();
            return telegramUsers.ToList();
        }

        public Task<bool> UpdateUserStatusAsync(int id, Status status)
        {
            throw new NotImplementedException();
        }
    }
}
