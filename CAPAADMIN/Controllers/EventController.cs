using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPAADMIN.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalogevent()
        {
            return View();
        }

        public ActionResult Addevent()
        {
            return View();
        }
        public ActionResult ModEvent()
        {
            return View();
        }
        public ActionResult EventInv()
        {
            return View();
        }
        public ActionResult AprovateEvent()
        {
            return View();
        }
    }
}