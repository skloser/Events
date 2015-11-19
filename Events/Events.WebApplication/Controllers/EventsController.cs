using Data.UnitOfWork;
using Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Events.WebApplication.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        [Authorize]
        public async Task AddEventAsync(Event e)
        {
           await Task.Run(() => AddEvent(e));
        }

        [Authorize]
        public void AddEvent(Event e)
        {
            IApplicationData data = new ApplicationData();
            e.CreatedOn = DateTime.Now;
            e.Host = data.Users.All().Where(u=>u.Email==User.Identity.Name).FirstOrDefault();
            data.Events.Add(e);
            data.SaveChanges();
        }
    }
}