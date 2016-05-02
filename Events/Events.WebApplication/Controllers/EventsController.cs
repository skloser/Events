namespace Events.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Events.Data;
    using Events.Model;
    using Microsoft.AspNet.Identity;
    using Model.Enumerations;
    using Models.Events;

    public class EventsController : Controller
    {
        private EventsDbContext context = new EventsDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = context.Events.Include(e => e.Teams).ToList();

            var player = CurrentPlayer();

            ViewBag.CurrentPlayer = player;
            return View(events);
        }

        public ActionResult AllEvents()
        {
            var allEvents = context.Events.ToList();
            var allEventsViewModel = new List<EventViewModel>();

            foreach (var sportEvent in allEvents)
            {
                var eventViewModel = new EventViewModel();
                eventViewModel.Title = sportEvent.Title;
                allEventsViewModel.Add(eventViewModel);
            }


            return View(allEventsViewModel);
        }

        // GET: MyEvents
        public ActionResult MyEvents()
        {
            var userId = this.User.Identity.GetUserId();
            var events = context.Events.Where(e => e.Host.UserId == userId).Include(e => e.Teams).ToList();
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event eventView = context.Events.Find(id);
            if (eventView == null)
            {
                return HttpNotFound();
            }
            return View(eventView);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event eventModel)
        {
            var errors = ModelState.Select(m => m.Value.Errors);
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }
            var player = CurrentPlayer();

            eventModel.HostId = player.PlayerId;
            eventModel.CreatedOn = DateTime.Now;
            //eventModel.StartTime = DateTime.Now;


            context.Events.Add(eventModel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult JoinEvent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var player = CurrentPlayer();

            var eventSearched = context.Events.Find(id);
            if (eventSearched == null)
            {
                return HttpNotFound();
            }
            //Player teams that fit the requirement of the event
            var playerTeams = player.MyTeams.Where(t => t.Players.Count == eventSearched.TeamMembersCapacity);
            ViewBag.Teams = playerTeams;
            return View((int)id);
        }

        [HttpPost]
        public ActionResult JoinEvent(int? id, int? TeamPicked)
        {
            if(id == null || TeamPicked == null)
            {
                return RedirectToAction("Index");
            }
            var eventToJoin = context.Events.Find(id.Value);
            if (eventToJoin == null)
            {
                return HttpNotFound();
            }
            
            var teamJoining = context.Teams.Find(TeamPicked.Value);
            if (teamJoining == null)
            {
                return HttpNotFound();
            }

            eventToJoin.Teams.Add(teamJoining);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult LeaveEvent(int id)
        {
            var player = CurrentPlayer();

            var eventToLeave = context.Events.Find(id);

            var eventTeams = eventToLeave.Teams.ToList();
            foreach (var team in eventTeams)
            {
                if (player.MyTeams.Contains(team))
                {
                    eventToLeave.Teams.Remove(team);
                }
            }


            context.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event eventToEdit = context.Events.Find(id);
            if (eventToEdit == null)
            {
                return HttpNotFound();
            }
            return View(eventToEdit);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            context.Entry(eventModel).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event eventToDelete = context.Events.Find(id);
            if (eventToDelete == null)
            {
                return HttpNotFound();
            }
            return View(eventToDelete);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event eventToDelete = context.Events.Find(id);
            context.Events.Remove(eventToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult MatchAssembles(int id)
        {
            var currentEvent = context.Events.Find(id);

            var allEventTeams = currentEvent.Teams.ToList();


            var allMatchesForCurrentEvent = this.GenerateEventMatches(allEventTeams, id);

            foreach (var match in allMatchesForCurrentEvent)
            {
                currentEvent.MatchStatistics.Add(match);

            }

            context.SaveChanges();

            return RedirectToAction("Index");
        }
        //    return RedirectToAction("DisplayAllEventMatches", id);
        //}

        public ActionResult EventMatches(int id)
        {
            var currentEvent = this.context.Events.Find(id);

            return View(currentEvent);
        }


        private List<Match> GenerateEventMatches(List<Team> teams, int eventID)
        {
            var matches = new List<Match>();
            var teamsToChange = teams.ToList();
            //var firstTeam = teamsToChange.First();
            for (int i = 0, j = teamsToChange.Count; i < j; i++)
            {
                var firstTeam = teamsToChange.First();
                teamsToChange.Remove(firstTeam);
                matches.AddRange(GenerateMatches(teamsToChange, firstTeam, eventID));
            }
            return matches;
        }

        private List<Match> GenerateMatches(List<Team> teamsToPlayWith, Team teamFirst, int eventId)
        {
            var matches = new List<Match>();
            foreach (var team in teamsToPlayWith)
            {
                var match = new Match();
                match.HomeTeam = teamFirst;
                match.GuestTeam = team;
                match.EventId = eventId;
                matches.Add(match);
            }
            return matches;
        }

        private Player CurrentPlayer()
        {
            var userId = this.User.Identity.GetUserId();
            var player = context.Players.FirstOrDefault(p => p.UserId == userId);
            return player;
        }

    }
}

