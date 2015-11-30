namespace Events.WebApplication.Controllers
{
    using Data;
    using Model.Statistics;
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
            List<MatchStatistic> userAllMatchStatistics = new List<MatchStatistic>();
            var userTeams = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().MyTeams;
            foreach (var userTeam in userTeams)
            {
                foreach (var homeGames in userTeam.HomeMatchStatistics)
                {
                    userAllMatchStatistics.Add(homeGames);
                }
                foreach (var awayGames in userTeam.GuestMatchStatistics)
                {
                    userAllMatchStatistics.Add(awayGames);
                }
            }
            var userAllMatchStatisticsOrdered = userAllMatchStatistics.OrderBy(m => m.Event);

            return View(userAllMatchStatisticsOrdered);
        }

    }
}