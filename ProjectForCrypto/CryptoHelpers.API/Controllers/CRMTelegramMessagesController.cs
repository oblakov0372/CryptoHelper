using CryptoHelpers.API.Models;
using Data.Context;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetTelegramMessages([FromQuery] TelegramMessagesParameters parameters)
        {
            var query = _context.TelegramMessages.AsQueryable();

            if (!string.Equals(parameters.MessageType, "all", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(m => m.Type == parameters.MessageType);
            }

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                query = query.Where(m => m.Message.Contains(parameters.SearchQuery));
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / parameters.PageSize);

            var telegramMessages = await query
                .OrderByDescending(m => m.Date)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return Ok(new { telegramMessages, countPages = totalPages });
        }
    }
}
