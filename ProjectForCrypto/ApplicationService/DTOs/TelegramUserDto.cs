
using Data.Entities;

namespace ApplicationService.DTOs
{
    public class TelegramUserDto
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public Status? Status { get; set; }
        public DateTime FirstActivity { get; set; }
        public DateTime LastActivity { get; set; }
        public int CountMessagesWtb { get; set; }
        public int CountMessagesWts { get; set; }
        public int CountAllMessages { get;set; }
        public string? LinkToUserTelegram { get; set; }
        public string? LinkToFirstMessage { get; set; }
    }
}
