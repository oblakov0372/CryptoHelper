namespace CryptoHelpers.API.Models
{
    public class TelegramMessagesParameters:QueryStringParameters
    {
        public TelegramMessagesParameters() {
            PageSize = 30;
            OrderBy = "date";
            MessageType = "all";
        }
        public string MessageType { get; set; }
    }
}
