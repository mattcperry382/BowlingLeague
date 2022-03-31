using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo { get; set; }

        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string team)
        {
            if (team == null)
            {
                ViewBag.Team = "";
            }
            else
            {
                ViewBag.Team = team;
            }

            var bowlers = _repo.Bowlers
                .Include(x => x.Team)
                .Where(x => x.Team.TeamName == team || team == null)
                .ToList();

            return View(bowlers);
        }

        public IActionResult Teams()
        {
            var teams = _repo.Teams.ToList();

            return View(teams);
        }
    }
}
