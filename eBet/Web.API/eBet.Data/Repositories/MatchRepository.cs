using eBet.Data.Entities;
using eBet.Data.Interfaces.Repositories;

namespace eBet.Data.Repositories
{
    public class MatchRepository : Repository<MatchEvent>, IMatchRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public MatchRepository(AppDbContext context) : base(context)
        {
        }
    }
}