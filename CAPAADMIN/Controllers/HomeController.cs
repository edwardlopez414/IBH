using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPAADMIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult reportes()
        {
            return View();
        }

        public ActionResult reporteevento()
        {
            return View();
        }
        public ActionResult Activity()
        {
            return View();
        }

        public ActionResult Cataloguser()
        {
            return View();
        }
        public ActionResult deleteuser()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}