using Data.Entities;
using System.ComponentModel.DataAnnotations;


namespace ApplicationService.Models.DealModels
{
    public class UpdateDealModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
