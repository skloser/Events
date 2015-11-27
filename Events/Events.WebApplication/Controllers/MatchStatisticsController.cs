using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Model;
using Events.Model.Statistics;
using Events.Data.Repositories;
namespace Events.WebApplication.Controllers
{
    public class MatchStatisticsController : Controller
    {
        // GET: MatchStatistics
        public ActionResult EventStats(int eventId=8)
        {
            var eventStats = new List<MatchStatistic>();
            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
                var context = new Data.EventsDbContext();
                 eventStats = context.MatchStatistics.Where(e => e.EventId == eventId).ToList();
            }
                return View("EventStats",eventStats);
        }
    }
}