namespace Events.WebApplication.Controllers
{
    using Data;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class StatisticsController : Controller
    {
        private EventsDbContext context = new EventsDbContext();

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserStatistics()
        {
            List<Match> userAllMatchStatistics = new List<Match>();
            var userTeams = context.Players.Where(u => u.User.UserName == User.Identity.Name).FirstOrDefault().MyTeams;
            foreach (var userTeam in userTeams)
            {
                foreach (var homeGames in userTeam.HomeMatches)
                {
                    userAllMatchStatistics.Add(homeGames);
                }
                foreach (var awayGames in userTeam.AwayMatches)
                {
                    userAllMatchStatistics.Add(awayGames);
                }
            }
            var userAllMatchStatisticsOrdered = userAllMatchStatistics.OrderBy(m => m.Event);

            return View(userAllMatchStatisticsOrdered);
        }

    }
}