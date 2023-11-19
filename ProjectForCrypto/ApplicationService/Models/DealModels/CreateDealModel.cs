using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApplicationService.Models.DealModels
{
    public class CreateDealModel
    {
        [Required]
        public Status Status { get; set; }
        [Required]
        public long TelegramUserId { get; set; }
    }
}
