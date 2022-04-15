using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;


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
            ViewBag.AllAtlantic = _context.Teams
                .Include(t => t.CurrLeague)
                .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference")
                .ToList();
            ViewBag.CurrPenguins = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.TeamName == "Penguins" && p.CurrentTeam.Location == "Boston")
                .ToList();
            ViewBag.CurrICBC = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
                .ToList();
            ViewBag.CurrACAFLopez = _context.Players
                .Include(p => p.CurrentTeam)
                .ThenInclude(t => t.CurrLeague)
                .Where(p => p.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football" && p.LastName == "Lopez")
                .ToList();
            ViewBag.FootballPlayers = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Sport == "Football")
                .ToList();
            ViewBag.SophiaTeams = _context.Teams
                .Include(t => t.CurrentPlayers)
                .Where(t => t.CurrentPlayers.Any(p => p.FirstName == "Sophia"))
                .ToList();
            ViewBag.SophiaLeagues = _context.Leagues
                .Include(l => l.Teams)
                .ThenInclude(t => t.CurrentPlayers)
                .Where(l => l.Teams.Any(t => t.CurrentPlayers.Any(p => p.FirstName == "Sophia")))
                .ToList();
            ViewBag.FloresNotRough = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.TeamName != "Roughriders" && p.CurrentTeam.Location != "Washington" && p.LastName == "Flores")
                .OrderBy(p => p.LastName)
                .ToList();
            
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            ViewBag.SamEvans = _context.Players
                .Include(p => p.AllTeams)
                    .ThenInclude(pt => pt.TeamOfPlayer)
                .FirstOrDefault(p => p.FirstName == "Samuel" && p.LastName == "Evans");
            ViewBag.MTTC = _context.Teams
                            .Include(t => t.AllPlayers)
                                .ThenInclude(pt => pt.PlayerOnTeam)
                            .FirstOrDefault(t => t.TeamName == "Tiger-Cats" && t.Location == "Manitoba");
            List<Player> players = _context.Players
                                            .Include(p => p.CurrentTeam)
                                            .Include(p => p.AllTeams)
                                                .ThenInclude(t => t.TeamOfPlayer)
                                            .ToList();
            ViewBag.FormerWichVikings = players.Where(p => p.CurrentTeam.TeamName != "Vikings" && p.AllTeams.Any(t => t.TeamOfPlayer.TeamName == "Vikings"));
            
            Player JG = _context.Players
                        .Include(p => p.CurrentTeam)
                        .Include(p => p.AllTeams)
                            .ThenInclude(t => t.TeamOfPlayer)
                        .FirstOrDefault(p => p.FirstName == "Jacob" && p.LastName == "Gray");
            ViewBag.JG = JG.AllTeams.Where(pt => pt.TeamOfPlayer.TeamName != "Colts" && pt.TeamOfPlayer.Location != "Oregon");

            ViewBag.Joshuas = _context.Players
                        .Include(p => p.AllTeams)
                            .ThenInclude(at => at.TeamOfPlayer)
                                .ThenInclude(top => top.CurrLeague)
                        .Where(p => p.FirstName == "Joshua" && p.AllTeams.Any(pt => pt.TeamOfPlayer.CurrLeague.Name =="Atlantic Federation of Amateur Baseball Players"))
                        .ToList();

            ViewBag.Twelve = _context.Teams
                .Where(t => t.AllPlayers.Count >= 12)
                .OrderBy(t => t.AllPlayers.Count)
                .ToList();

            ViewBag.AllPlayersByTeamCount = _context.Players
                .OrderBy(p => p.AllTeams.Count)
                .ToList();
            
            return View();
        }

    }
}