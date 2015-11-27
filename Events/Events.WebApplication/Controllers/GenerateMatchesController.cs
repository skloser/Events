using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.WebApplication.GenerateMatches;
using Events.Model;
namespace Events.WebApplication.Controllers
{
    public class GenerateMatchesController : Controller
    {
        // GET: GenerateMatches
        public ActionResult Index()
        {
            var teams = new Dictionary<Team, int>();
            List<Team> teamList = new List<Team>();
            for (int i = 0; i < 16; i++)
            {
                Team t1 = new Team
                {
                    TeamId = i+1,
                    Name = "Team " + (i+1),
                    Members = new HashSet<User>()
                {
                    new User
                    {
                        FirstName = "Player "+(i+1),
                        LastName =  "Last Name "+(i+1)
                    }
                },
                };
                teamList.Add(t1);
            }

            for (int i = 0; i < teamList.Count; i++)
            {
                teams.Add(teamList[i], i + 1);
            }

           var allMatches = MatchGenerator.GenerateMatches(teams,4);
            return View(allMatches);
        }
    }
}