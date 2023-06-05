using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPAADMIN.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RPEvent()
        {
            return View();
        }
        public ActionResult RPMiembro()
        {
            return View();
        }
        public ActionResult RPAsistencia()
        {
            return View();
        }
        public ActionResult RPProveedores()
        {
            return View();
        }
        public ActionResult RPPEfectuados()
        {
            return View();
        }
    }
}