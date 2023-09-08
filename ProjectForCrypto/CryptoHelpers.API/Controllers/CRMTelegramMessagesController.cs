using Data.Context;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoHelpers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRMTelegramMessagesController : BaseContoller
    {
        private readonly ProjectDBContext _context;
        public CRMTelegramMessagesController(ProjectDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetTelegramMessages()
        {
            List<TelegramMessageEntity> telegramMessages = await _context.TelegramMessages.ToListAsync();
            return Ok(telegramMessages);
        }

    }
}
