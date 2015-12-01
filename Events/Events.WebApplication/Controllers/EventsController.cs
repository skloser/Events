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

    public class EventsController : Controller
    {
        private EventsDbContext context = new EventsDbContext();

        //public EventsController()
        //{
        //    this.context = new UnitOfWork(new EventsDbContext());
        //}
        

        // GET: Events
        public ActionResult Index()
        {
            var events = context.Events;

            var currentUserId = this.User.Identity.GetUserId();
            var player = context.Players.Where(pl => pl.UserId == currentUserId);

            ViewBag.CurrentPlayer = player;
            return View(events);
        }

        // GET: MyEvents
        public ActionResult MyEvents()
        {
            var events = context.Events.Where(e => e.Host.UserId == this.User.Identity.GetUserId());
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

            string userId = this.User.Identity.GetUserId();
            var player = context.Players.FirstOrDefault(p => p.UserId == userId);

            eventModel.HostId = player.PlayerId;
            eventModel.CreatedOn = DateTime.Now;
            eventModel.StartTime = DateTime.Now;


            context.Events.Add(eventModel);
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
    }
}

