using eBet.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBet.Common.Responses.Matches
{
    public class MatchesForTheNextDayResponse
    {

        public string ID { get; init; }
        public string Name { get; init; }
        public string MatchType { get; init; }
        public DateTime StartDate { get; init; }
        public string EventID { get; init; }
        public Event Event { get; init; }
    }
}
