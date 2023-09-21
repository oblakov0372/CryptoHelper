

using Contracts;
using Data.Context;
using Data.Entities;

namespace Repository
{
    public class TelegramMessageRepository:GenericRepository<TelegramMessageEntity>,ITelegramMessageRepository
    {
        public TelegramMessageRepository(ProjectDBContext dbContext) : base(dbContext) { }
    }
}
