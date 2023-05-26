using eBet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBet.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISportRepository Sports { get; }
        IEventRepository Events { get; }
        IMatchRepository Matches { get; }
        IBetRepository Bets { get; }
        IOddRepository Odds { get; }
        Task<int> CommitAsync();
        Task EnsureCreatedAsync(CancellationToken stoppingToken);
    }
}
