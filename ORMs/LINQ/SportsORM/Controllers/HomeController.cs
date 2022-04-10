using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // ...all womens' leagues
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();
            // ...all leagues where sport is any type of hockey
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            // ...all leagues where sport is something OTHER THAN football
            ViewBag.NonFootballLeagues = _context.Leagues
                .Where(l => l.Sport != "Football")
                .ToList();
            // ...all leagues that call themselves "conferences"
            ViewBag.Conferences = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            // ... all leagues in the Atlantic region
            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            // ...all teams based in Dallas
            ViewBag.DallasTeams = _context.Teams
                .Where(t => t.Location == "Dallas")
                .ToList();
            // ...alll teams names the Raptors
            ViewBag.RaptorsTeams = _context.Teams
                .Where(t => t.TeamName.Contains("Raptors"))
                .ToList();
            // ...all teams whose location includes City
            ViewBag.CityTeams = _context.Teams
                .Where(t => t.Location.Contains("City"))
                .ToList();
            // ...all teams whose names start with T
            ViewBag.TTeams = _context.Teams
                .Where(t => t.TeamName.Contains("T"))
                .ToList();
            // ... all teams, ordered alphabetically by location
            ViewBag.LocationTeams = _context.Teams
                .OrderBy(t => t.Location)
                .ToList();
            // ... all teams, ordered by team name in reverse alpha
            ViewBag.RevNameTeams = _context.Teams
                .OrderByDescending(t => t.TeamName)
                .ToList();
            // ... every Player with last name Cooper
            ViewBag.Cooper = _context.Players
                .Where(p => p.LastName == "Cooper")
                .ToList();
            // ... every Player with First name Joshua
            ViewBag.Joshua = _context.Players
                .Where(p => p.FirstName == "Joshua")
                .ToList();
            // ... every Player with last name Cooper Except those with FN Joshua
            ViewBag.CoopersansJoshua = _context.Players
                .Where(p => p.LastName == "Cooper" && p.FirstName != "Joshua")
                .ToList();
            // ... every Player with First name Alexander or Wyatt
            ViewBag.AlexorWyatt = _context.Players
                .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt")
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}