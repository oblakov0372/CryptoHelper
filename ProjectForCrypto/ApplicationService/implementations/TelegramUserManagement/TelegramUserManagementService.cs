using ApplicationService.DTOs;
using Contracts;
using Data.Entities;

namespace ApplicationService.implementations.TelegramUserManagement
{
    public class TelegramUserManagementService : ITelegramUserManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TelegramUserManagementService(IUnitOfWork unitOfWork)
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

        //public async Task<List<TelegramMessageEntity>>
    }
}
