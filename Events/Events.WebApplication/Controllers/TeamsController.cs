using Events.Data;
using Events.Model;
using Events.WebApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.WebApplication.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        private static readonly EventsDbContext context = new EventsDbContext();

        // GET: Teams
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            if (!this.ModelState.IsValid)
            {
                return View(this.ModelState);
            }

            string firstPlayerToJoin = this.User.Identity.GetUserId();

            var player = context.Players.FirstOrDefault(p => p.UserId == firstPlayerToJoin);

            var teamToAdd = new Team
            {
                Name = team.Name
            };

            teamToAdd.Players.Add(player);
            context.Teams.Add(teamToAdd);
            context.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult CreateTeam()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult JoinTeam()
        {
            List<TeamsViewModel> allTeams = new List<TeamsViewModel>();

            var getAllTeams = context.Teams.ToList();

            foreach (var team in getAllTeams)
            {

                var members = team.Players.ToList();

                var teamToAdd = new TeamsViewModel
                {
                    TeamViewModelId = team.TeamId,
                    Name = team.Name,
                    Members = members
                };

                allTeams.Add(teamToAdd);
            }

            var userId = this.User.Identity.GetUserId();
            var player = context.Players.FirstOrDefault(u => u.UserId == userId);

            ViewBag.CurrentPlayerId = player.PlayerId;
            return this.View(allTeams);
        }


        public ActionResult Join(int id)
        {
            var team = context.Teams.FirstOrDefault(t => t.TeamId == id);

            string userId = this.User.Identity.GetUserId();

            var player = context.Players.FirstOrDefault(p => p.UserId == userId);

            team.Players.Add(player);
            context.SaveChanges();

            return RedirectToAction("JoinTeam");
        }

        public ActionResult Leave(int id)
        {
            var team = context.Teams.FirstOrDefault(t => t.TeamId == id);

            string userId = this.User.Identity.GetUserId();

            var player = context.Players.FirstOrDefault(p => p.UserId == userId);

            team.Players.Remove(player);
            context.SaveChanges();

            return RedirectToAction("JoinTeam");
        }

    }
}