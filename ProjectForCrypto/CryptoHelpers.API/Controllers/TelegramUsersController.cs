using ApplicationService.implementations.TelegramUserManagement;
using Contracts;
using CryptoHelpers.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<IActionResult> GetTelegramUsers([FromQuery] TelegramUsersParameters queryParams)
        {
            var query = await _telegramUserService.GetAllTelegramUsersAsync();

            if(!string.IsNullOrEmpty(queryParams.SearchQuery))
    {
                var byUsername = query
                    .Where(u => u.TelegramUsername != null && u.TelegramUsername.ToLower().Contains(queryParams.SearchQuery.ToLower()))
                    .ToList();

                var byId = query
                    .Where(u => u.Id.ToString().Contains(queryParams.SearchQuery))
                    .ToList();

                query = byUsername.Concat(byId).ToList();
            }

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / queryParams.PageSize);

            var telegramUsers = query
                
                .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                .Take(queryParams.PageSize)
                .ToList();

            return Ok(new { telegramUsers, countPages = totalPages });
        }
    }
}
