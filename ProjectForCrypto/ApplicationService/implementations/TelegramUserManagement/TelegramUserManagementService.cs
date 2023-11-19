using ApplicationService.DTOs;
using ApplicationService.implementations.TelegramMessagesManagement;
using Contracts;
using Data.Entities;

namespace ApplicationService.implementations.TelegramUserManagement
{
    public class TelegramUserManagementService : ITelegramUserManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITelegramMessagesManagementService _telegramMessagesManagementService;
        public TelegramUserManagementService(IUnitOfWork unitOfWork, ITelegramMessagesManagementService telegramMessagesManagementService)
        {
            _unitOfWork = unitOfWork;
            _telegramMessagesManagementService = telegramMessagesManagementService;
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

        public async Task<TelegramUserDto> GetDataForTelegramUserAsync(long userId)
        {
            var userEntity = (await _unitOfWork.TelegramUsers.FindAsync(u => u.Id == userId)).FirstOrDefault();

            var telegramUserMessages = await _telegramMessagesManagementService.GetTelegramMessagesByUserIdAsync(userId);
            var telegramUserDto = new TelegramUserDto
            {
                Id = userId,
                UserName = userEntity.TelegramUsername,
                Status = userEntity.Status,
                FirstActivity = telegramUserMessages.First().Date,
                LastActivity = telegramUserMessages.Last().Date,
                CountAllMessages = telegramUserMessages.Count(),
                CountMessagesWtb = telegramUserMessages.Where(message => message.Type.Equals("wtb")).Count(),
                CountMessagesWts = telegramUserMessages.Where(message => message.Type.Equals("wts")).Count(),
                LinkToUserTelegram = userEntity.TelegramUsername != null ? $"https://t.me/{userEntity.TelegramUsername}" : null,
                LinkToFirstMessage = telegramUserMessages.First().LinkForMessage,
            };
            return telegramUserDto;
        }
    }
}
