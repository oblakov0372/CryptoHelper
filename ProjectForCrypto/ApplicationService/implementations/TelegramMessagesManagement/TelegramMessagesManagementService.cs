using Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.implementations.TelegramMessagesManagement
{
    public class TelegramMessagesManagementService : ITelegramMessagesManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TelegramMessagesManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TelegramMessageEntity>> GetAllTelegramMessagesAsync()
        {
            var telegramMessages = await _unitOfWork.TelegramMessages.GetAllAsync();
            return telegramMessages.ToList();
        }

        public List<TelegramMessageEntity> GetTelegramMessagesByUserId(long userId)
        {
            var telegramMessages = _unitOfWork.TelegramMessages.FindAsync(m => m.SenderId == userId);
            return telegramMessages.ToList();
        }
    }
}
