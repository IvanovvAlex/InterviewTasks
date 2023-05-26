using eBet.Data.Entities;
using eBet.Data.Interfaces.Repositories;

namespace eBet.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public EventRepository(AppDbContext context) : base(context)
        {
        }
    }
}