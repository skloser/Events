using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.WebApplication.Controllers
{
    public class JQueryDragAndDropController : Controller
    {
        // GET: JQueryDragAndDrop
        public ActionResult Index()
        {
            return View("DragAndDrop");
        }
    }
}