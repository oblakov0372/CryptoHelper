
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Deals")]
    public class DealEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatorUserId { get; set; }
        [ForeignKey(nameof(CreatorUserId))]
        public UserEntity User { get; set; }
        public long TelegramUserId { get; set; }
        [ForeignKey(nameof(TelegramUserId))]
        public TelegramUserEntity TelegramUser { get; set; }

    }
}
