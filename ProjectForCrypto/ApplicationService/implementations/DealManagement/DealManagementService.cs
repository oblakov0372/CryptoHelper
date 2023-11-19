using ApplicationService.Models.DealModels;
using Contracts;
using Data.Entities;

namespace ApplicationService.implementations.DealManagement
{
    public class DealManagementService : IDealManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DealManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<DealEntity>> GetAllDealsAsync()
        {
            var deals = await _unitOfWork.Deals.GetAllAsync();
            return deals.ToList();
        }
        public async Task<List<DealEntity>> GetAllDealsByUserIdAsync(int creatorId)
        {
            var dealsByUserId = await _unitOfWork.Deals.FindAsync(deal => deal.CreatorUserId == creatorId);
            return dealsByUserId.ToList();
        }
        public async Task<DealEntity> CreateDealAsync(CreateDealModel model, int creatorId)
        {
            var createdDeal = new DealEntity
            {
                Status = model.Status,
                TelegramUserId = model.TelegramUserId,
                CreatedDateTime = DateTime.Now,
                CreatorUserId = creatorId,
            };
            await _unitOfWork.Deals.AddAsync(createdDeal);
            await _unitOfWork.SaveAsync();
            return createdDeal;
        }
        public async Task<bool> UpdateDealAsync(UpdateDealModel model, int creatorId)
        {
            DealEntity dealForUpdate = await _unitOfWork.Deals.GetByIdAsync(model.Id);
            if (dealForUpdate == null)
                return false;

            dealForUpdate.Status = model.Status;
            return true;
        }
        public async Task<bool> DeleteDealAsync(int dealId)
        {
            DealEntity dealForDelete = await _unitOfWork.Deals.GetByIdAsync(dealId);
            if (dealForDelete == null)
                return false;

            _unitOfWork.Deals.Remove(dealForDelete);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
