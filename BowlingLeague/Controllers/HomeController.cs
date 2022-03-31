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

        public IActionResult Index()
        {
            var bowlers = _repo.Bowlers
                .Include(x => x.Team)
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
