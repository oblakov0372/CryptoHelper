using ApplicationService.implementations.TelegramMessagesManagement;
using CryptoHelpers.API.Models;
using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CryptoHelpers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRMTelegramMessagesController : BaseContoller
    {
        private readonly ITelegramMessagesManagementService _telegramMessagesManagementService;

        public CRMTelegramMessagesController(ITelegramMessagesManagementService telegramMessagesManagementService)
        {
           _telegramMessagesManagementService = telegramMessagesManagementService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTelegramMessages([FromQuery] TelegramMessagesParameters parameters)
        {
            var allTelegramMessages = await _telegramMessagesManagementService.GetAllTelegramMessagesAsync();

            if (!string.Equals(parameters.MessageType, "all", StringComparison.OrdinalIgnoreCase))
            {
                allTelegramMessages = allTelegramMessages.Where(m => m.Type == parameters.MessageType).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                allTelegramMessages = allTelegramMessages.Where(m => m.Message.Contains(parameters.SearchQuery)).ToList();
            }

            var totalCount = allTelegramMessages.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / parameters.PageSize);

            var telegramMessages = allTelegramMessages
                .OrderByDescending(m => m.Date)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();

            return Ok(new { telegramMessages, countPages = totalPages });
        }
    }
}
