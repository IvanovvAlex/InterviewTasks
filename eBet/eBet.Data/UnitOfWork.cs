using eBet.Data.Interfaces;
using eBet.Data.Interfaces.Repositories;
using eBet.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBet.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly ISportRepository _sportRepository;

        private readonly IEventRepository _eventRepository;

        private readonly IMatchRepository _matchRepository;

        private readonly IBetRepository _betRepository;

        private readonly IOddRepository _oddRepository;

        public UnitOfWork(AppDbContext context, ISportRepository sportRepository, IEventRepository eventRepository, IMatchRepository matchRepository, IBetRepository betRepository, IOddRepository oddRepository)
        {
            _context = context;
            _sportRepository = sportRepository;
            _eventRepository = eventRepository;
            _matchRepository = matchRepository;
            _betRepository = betRepository;
            _oddRepository = oddRepository;
        }

        public ISportRepository Sports => _sportRepository ?? new SportRepository(_context);

        public IEventRepository Events => _eventRepository ?? new EventRepository(_context);

        public IMatchRepository Matches => _matchRepository ?? new MatchRepository(_context);

        public IBetRepository Bets => _betRepository ?? new BetRepository(_context);

        public IOddRepository Odds => _oddRepository ?? new OddRepository(_context);

        public async Task EnsureCreatedAsync(CancellationToken stoppingToken)
        {
            await _context.Database.EnsureCreatedAsync(stoppingToken);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
