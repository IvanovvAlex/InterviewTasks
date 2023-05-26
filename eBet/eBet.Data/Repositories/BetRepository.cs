using eBet.Data.Entities;
using eBet.Data.Interfaces.Repositories;

namespace eBet.Data.Repositories
{
    public class BetRepository : Repository<Bet>, IBetRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public BetRepository(AppDbContext context) : base(context)
        {
        }
    }
}