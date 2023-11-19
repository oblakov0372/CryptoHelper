

using ApplicationService.Models.DealModels;
using Data.Entities;

namespace ApplicationService.implementations.DealManagement
{
    public interface IDealManagementService
    {
        Task<List<DealEntity>> GetAllDealsAsync();
        Task<List<DealEntity>> GetAllDealsByUserIdAsync(int creatorId);
        Task<DealEntity> CreateDealAsync(CreateDealModel model,int creatorId);
        Task<bool> UpdateDealAsync(UpdateDealModel model, int creatorId);
        public Task<bool> DeleteDealAsync(int dealId);

    }
}
