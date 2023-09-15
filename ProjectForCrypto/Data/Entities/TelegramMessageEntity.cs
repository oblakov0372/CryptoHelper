using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("TelegramMessages")]
    public class TelegramMessageEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("telegram_group_id")]
        public long TelegramGroupId { get; set; }
        [Column("telegram_group_username")]
        public string? TelegramGroupUsername { get; set; }
        [Column("sender_id")]
        public long SenderId { get; set; }
        [Column("sender_username")]
        public string? SenderUsername { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        [Column("link_for_message")]
        public string? LinkForMessage { get; set; }
        private string? _type;
        [Column("Type")]
        public string? Type
        {
            get
            {
                return _type ?? "None";
            }
            set
            {
                _type = value;
            }
        }

    }
}
