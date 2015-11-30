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
using Events.Data.Repositories;
using Events.Model.Statistics;

namespace Events.WebApplication.Controllers
{
    public class EventsController : Controller
    {
        private EventsDbContext context = new EventsDbContext();

        //public EventsController()
        //{
        //    this.context = new UnitOfWork(new EventsDbContext());
        //}

        //public EventsController(IUnitOfWork context)
        //{
        //    this.context = context;
        //}

        // GET: Events
        public ActionResult Index()
        {
            var events = context.Events.Where(e => e.Host.UserName == User.Identity.Name);
            
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = context.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            //ViewBag.Host = this.User.Identity;
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,Title,CreatedOn,StartTime,TeamMembersCapacity,NumberOfTeams,TypeOfEventFormat,TypeOfTeamAssemble,HostId,Description")] Event eventModel)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.HostId = new SelectList(context.Users, "Id", "FirstName", @event.HostId);
                return View(eventModel);
            }
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
            Event @event = context.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            //ViewBag.HostId = new SelectList(context.Users, "Id", "FirstName", @event.HostId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Title,CreatedOn,StartTime,Capacity,TypeOfEventFormat,TypeOfTeamAssemble,HostId,Description")] Event @event)
        {
            
            
            if (ModelState.IsValid)
            {
                //context.Entry(@event).State = EntityState.Modified;
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.HostId = new SelectList(context.Users, "Id", "FirstName", @event.HostId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = context.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = context.Events.Find(id);
            context.Events.Remove(@event);
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

