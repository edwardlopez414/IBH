﻿using capaentidad;
using capanegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPAADMIN.Controllers
{
    [Authorize]
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
        [HttpPost]
        public ActionResult ModEvent( int Idevento,string Nombre, string Tipo_asistente)
        {
            
            if(Nombre!= "")
            {
                TempData["Id_Usuario"] = Idevento;
                TempData["Nevento"] = Nombre;
                return RedirectToAction("asistencia");
            }
            else
            return View();
        }
        public JsonResult addasistencia( Asistente OBJ)
        {
            
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().agregarasis(OBJ, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult deleteasis(string Nombre , int eventoid)
        {

            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().Dltasis(Nombre,eventoid, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AprobarEvent(int eventoid)
        {

            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().Aevent(eventoid, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DesCevent(int eventoid)
        {

            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().DescartarE(eventoid, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Modificarevento(EVENTO OBJ)
        {

            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().MODevent(OBJ, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult catalogasis(int Idevent)
        {
            
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().catalogA(Idevent, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EventInv()
        {
            return View();
        }
        public ActionResult AprovateEvent()
        {
            return View();
        }

        public ActionResult asistencia()
        {
            return View();
        }
        public JsonResult Reportvento(string FI, string FF, string USER)
        {
            List<ReportEvent> olistaevent = new List<ReportEvent>();
            olistaevent = new CNEVENTO().Repvento(FI,FF,USER);
            return Json(new { data = olistaevent }, JsonRequestBehavior.AllowGet);
        }
    }
}