using Data.Entities;
using Data.Entities.CryptoTracker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class ProjectDBContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public ProjectDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TradeFutureEntity> Trades { get; set; }
        public DbSet<PortfolioEntity> Portfolios { get; set; }
        public DbSet<TransactionEntity> Trasnactions { get; set; }
        public DbSet<PortfolioTokenEntity> PortfolioTokens { get; set; }
        public DbSet<TelegramMessageEntity> TelegramMessages { get; set; }
        public DbSet<TelegramUserEntity> TelegramUsers { get; set; }
        public DbSet<DealEntity> Deals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProjectDBContext"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
