using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; } 
    }
}
