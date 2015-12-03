using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.WebApplication.Controllers
{
    public class GenerateMatchesController : Controller
    {
        // GET: GenerateMatches
        public ActionResult Index()
        {
            return View("GenerateFixture");
        }
    }
}