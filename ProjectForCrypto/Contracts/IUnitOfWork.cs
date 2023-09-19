﻿using Contracts.CryptoTracker;

namespace Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        ITradeFutureRepository TradeFutures { get; }
        IUserRepository Users { get; }
        IPortfolioRepository Portfolios { get; }
        ITransactionRepository Transactions { get; }
        IPortfolioTokenRepository PortfolioTokens { get; }
        ITelegramUserRepository TelegramUsers { get; }
        Task SaveAsync();
    }
}
