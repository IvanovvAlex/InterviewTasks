using eBet.Data.Entities;
using eBet.Data.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace eBet.Data.Repositories
{
    public class SportRepository : Repository<Sport>, ISportRepository
    {
        private AppDbContext AppDbContext => Context as AppDbContext;

        public SportRepository(AppDbContext context) : base(context)
        {
        }
    }
}