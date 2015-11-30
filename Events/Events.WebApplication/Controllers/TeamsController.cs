using Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.WebApplication.Controllers
{
    public class TeamsController : Controller
    {
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

            var teamToAdd = new Team
            {
                Name = team.Name,
            };

            return View();
        }
    }
}