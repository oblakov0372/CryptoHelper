using ApplicationService.implementations.TelegramUserManagement;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoHelpers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramUsersController : BaseContoller
    {
        private readonly ITelegramUserService _telegramUserService;

        public TelegramUsersController(ITelegramUserService telegramUserService)
        {
            _telegramUserService = telegramUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTelegramUsers()
        {
            var telegramUsers = await _telegramUserService.GetAllTelegramUsersAsync();

            return Ok(telegramUsers);
        }
    }
}
