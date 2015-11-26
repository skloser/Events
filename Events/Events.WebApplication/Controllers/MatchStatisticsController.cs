using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Model;
using Events.Data.Repositories;
namespace Events.WebApplication.Controllers
{
    public class MatchStatisticsController : Controller
    {
        // GET: MatchStatistics
        public ActionResult Stats(int eventId=8)
        {
            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
                // var stats = data.MatchStatistics.GetAllStats();
                // var estats = data.MatchStatistics.GetEventStats(11);
                var context = new Data.EventsDbContext();
                var eventStats = context.MatchStatistics.Where(e => e.EventId == 8);
            }
                return View();
        }
    }
}