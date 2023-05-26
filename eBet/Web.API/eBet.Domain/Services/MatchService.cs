using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using eBet.Data.Entities;
using eBet.Data.Interfaces;
using eBet.Domain.Interfaces;

namespace eBet.Domain.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MatchEvent>> GetAll()
        {
            return await _unitOfWork.Matches.GetAllAsync();
        }

        public async Task<MatchEvent> GetById(string id)
        {
            return await _unitOfWork.Matches.GetByIdAsync(id);
        }
    }
}
