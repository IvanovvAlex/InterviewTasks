using AutoMapper;
using eBet.Common.Responses.Matches;
using eBet.Data.Entities;
using eBet.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace eBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchesController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<IEnumerable<MatchesForTheNextDayResponse>> GetForTheNextDay()
        {
            IEnumerable<MatchEvent> matches = await _matchService.GetAll();

            IEnumerable<MatchesForTheNextDayResponse> response = _mapper.Map<IEnumerable<MatchEvent>, IEnumerable<MatchesForTheNextDayResponse>>(matches);

            return response;
        }

        [HttpGet("Details/{id}")]
        public async Task<MatchByIdResponse> Details(string id)
        {
            MatchEvent match = await _matchService.GetById(id);

            MatchByIdResponse response = _mapper.Map<MatchEvent, MatchByIdResponse>(match);

            return response;
        }
    }
}
