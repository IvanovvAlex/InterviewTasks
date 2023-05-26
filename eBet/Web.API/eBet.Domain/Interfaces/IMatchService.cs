using eBet.Data.Entities;

namespace eBet.Domain.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchEvent>> GetAll();
        Task<MatchEvent> GetById(string id);
    }
}