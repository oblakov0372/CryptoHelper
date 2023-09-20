
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public enum Status
    {
        Scamer,
        Reseller 
    }
    [Table("TelegramUsers")]
    public class TelegramUserEntity
    {
        public long Id { get; set; } 
        public string? TelegramUsername { get; set; }
        public Status? Status { get; set; }
    }
}
