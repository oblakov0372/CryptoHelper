
using Data.Entities;

namespace ApplicationService.DTOs
{
    public class TelegramUserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public Status Status { get; set; }
        public int FirstMessageId { get; set; }
        public DateTime FirstMessage { get; set; }
        public DateTime LastMessage { get; set; }
        public int MessagesWtb { get; set; }
        public int MessagesWts { get; set; }
        public int AllMessages { get;set; }
    }
}
