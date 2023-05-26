using eBet.Data.Entities;
using eBet.Data.Interfaces.Repositories;

namespace eBet.Data.Repositories
{
    public class OddRepository : Repository<Odd>, IOddRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public OddRepository(AppDbContext context) : base(context)
        {
        }
    }
}