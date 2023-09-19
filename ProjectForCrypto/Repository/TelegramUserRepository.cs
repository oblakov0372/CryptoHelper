using Contracts;
using Data.Context;
using Data.Entities;

namespace Repository
{
    public class TelegramUserRepository:GenericRepository<TelegramUserEntity>,ITelegramUserRepository
    {
        public TelegramUserRepository(ProjectDBContext dbContext) : base(dbContext) { }
    }
}
