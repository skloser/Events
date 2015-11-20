//namespace Events.WebApplication.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data;
//    using System.Data.Entity;
//    using System.Linq;
//    using System.Net;
//    using System.Web;
//    using System.Web.Mvc;
//    using Events.Data;
//    using Events.Model.Statistics;
//    using Data.Repositories;

//    public class MatchStatisticsController : Controller
//    {
//        private IUnitOfWork db;

//        // GET: MatchStatistics
//        public ActionResult Index()
//        {
//            this.db = new UnitOfWork(new EventsDbContext());
//            return View();
//        }

//        // GET: MatchStatistics/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            MatchStatistic matchStatistic = db.MatchStatistics.Find(id);
//            if (matchStatistic == null)
//            {
//                return HttpNotFound();
//            }
//            return View(matchStatistic);
//        }

//        // GET: MatchStatistics/Create
//        public ActionResult Create()
//        {
//            ViewBag.EventId = new SelectList(db.Events, "EventId", "Title");
//            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name");
//            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name");
//            return View();
//        }

//        // POST: MatchStatistics/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "MatchStatisticId,HomeTeamId,GuestTeamId,TimeOfMatch,HomeTeamResult,GuestTeamResult,EventId")] MatchStatistic matchStatistic)
//        {
//            if (ModelState.IsValid)
//            {
//                db.MatchStatistics.Add(matchStatistic);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.EventId = new SelectList(db.Events, "EventId", "Title", matchStatistic.EventId);
//            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name", matchStatistic.GuestTeamId);
//            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name", matchStatistic.HomeTeamId);
//            return View(matchStatistic);
//        }

//        // GET: MatchStatistics/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            MatchStatistic matchStatistic = db.MatchStatistics.Find(id);
//            if (matchStatistic == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.EventId = new SelectList(db.Events, "EventId", "Title", matchStatistic.EventId);
//            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name", matchStatistic.GuestTeamId);
//            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name", matchStatistic.HomeTeamId);
//            return View(matchStatistic);
//        }

//        // POST: MatchStatistics/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "MatchStatisticId,HomeTeamId,GuestTeamId,TimeOfMatch,HomeTeamResult,GuestTeamResult,EventId")] MatchStatistic matchStatistic)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(matchStatistic).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.EventId = new SelectList(db.Events, "EventId", "Title", matchStatistic.EventId);
//            ViewBag.GuestTeamId = new SelectList(db.Teams, "TeamId", "Name", matchStatistic.GuestTeamId);
//            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name", matchStatistic.HomeTeamId);
//            return View(matchStatistic);
//        }

//        // GET: MatchStatistics/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            MatchStatistic matchStatistic = db.MatchStatistics.Find(id);
//            if (matchStatistic == null)
//            {
//                return HttpNotFound();
//            }
//            return View(matchStatistic);
//        }

//        // POST: MatchStatistics/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            MatchStatistic matchStatistic = db.MatchStatistics.Find(id);
//            db.MatchStatistics.Remove(matchStatistic);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
