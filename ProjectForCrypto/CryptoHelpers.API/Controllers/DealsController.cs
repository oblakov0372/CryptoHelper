using ApplicationService.implementations.DealManagement;
using ApplicationService.Models.DealModels;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CryptoHelpers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : BaseContoller
    {
        private readonly IDealManagementService _dealManagementService;
        public DealsController(IDealManagementService dealManagementService)
        {
            _dealManagementService = dealManagementService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllDealsAsaync()
        {
            var deals = await _dealManagementService.GetAllDealsAsync();
            
            return Ok(deals);
        }
        [Authorize]
        [HttpGet("GetAllDealsByUser")]
        public async Task<IActionResult> GetAllDealsByUserIdAsync()
        {
            int userId = GetUserId();
            var deals = await _dealManagementService.GetAllDealsByUserIdAsync(userId);
           
            return Ok(deals);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDealAsync([FromBody] CreateDealModel createDealModel)
        {
            int userId = GetUserId();
            var createdDeal =  await _dealManagementService.CreateDealAsync(createDealModel, userId);
            
            return Ok(createdDeal);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDealAsync([FromBody] UpdateDealModel updateDealModel)
        {
            int userId = GetUserId();
            bool isUpdated = await _dealManagementService.UpdateDealAsync(updateDealModel, userId);
            if(isUpdated) 
                return Ok();

            return BadRequest();
        }
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteDealAsync(int dealId)
        {
            bool isDeleted = await _dealManagementService.DeleteDealAsync(dealId);
            if (isDeleted)
                return Ok();

            return BadRequest();
        }
    }
}
