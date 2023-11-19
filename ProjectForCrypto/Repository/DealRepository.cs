using Contracts;
using Data.Context;
using Data.Entities;

namespace Repository
{
    public class DealRepository: GenericRepository<DealEntity>,IDealRepository
    {
        public DealRepository(ProjectDBContext dbContext) : base(dbContext) { }
    }
}
