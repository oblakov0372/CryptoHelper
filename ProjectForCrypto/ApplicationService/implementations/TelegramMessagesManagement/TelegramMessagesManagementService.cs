using Contracts;
using Data.Entities;
using Microsoft.Extensions.Caching.Memory;


namespace ApplicationService.implementations.TelegramMessagesManagement
{
    public class TelegramMessagesManagementService : ITelegramMessagesManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;
        public TelegramMessagesManagementService(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TelegramMessageEntity>> GetAllTelegramMessagesAsync()
        {
            if (!_memoryCache.TryGetValue("TelegramMessages", out List<TelegramMessageEntity> values))
            {
                var telegramMessages = await _unitOfWork.TelegramMessages.GetAllAsync();

                // Store the value in the cache for 10 minutes.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                _memoryCache.Set("TelegramMessages", telegramMessages, cacheEntryOptions);
            }

            return values.ToList();
        }

        public async Task<List<TelegramMessageEntity>> GetTelegramMessagesByUserIdAsync(long userId)
        {
            var allMessage = await GetAllTelegramMessagesAsync();

            return allMessage.Where(m => m.SenderId == userId).ToList();
        }
    }
}
