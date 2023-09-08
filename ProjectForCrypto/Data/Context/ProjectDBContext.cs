using Data.Entities;
using Data.Entities.CryptoTracker;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ProjectDBContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TradeFutureEntity> Trades { get; set; }
        public DbSet<PortfolioEntity> Portfolios { get; set; }
        public DbSet<TransactionEntity> Trasnactions { get; set; }
        public DbSet<PortfolioTokenEntity> PortfolioTokens { get; set; }
        public DbSet<TelegramMessageEntity> TelegramMessages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OBLAKOV0372;Database=CryptoHelper;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
