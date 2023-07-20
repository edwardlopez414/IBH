using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaentidad;
using capanegocio;
namespace CAPAADMIN.Controllers
{
    [Authorize]
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
        // vistas relacioadas a usuarios capa admin
        public ActionResult Cataloguser()
        {
            return View();
        }
        public ActionResult deleteuser()
        {
            return View();
        }
        public ActionResult Adduser()
        {
            return View();
        }
        public ActionResult Moduser()
        {
            return View();
        }
        public ActionResult habuser()
        {
            return View();
        }
        public ActionResult error()
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
        public JsonResult MIEMBROS(string cedula = "") {

            List<Miembro> oLista = new List<Miembro>();
            oLista = new CNMIEMBRO().Miembro(cedula);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
       

        public JsonResult AddMiembro(Miembro obj)
        {
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNMIEMBRO().AddUser(obj, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModuserBD(Miembro obj)
        {
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNMIEMBRO().Moduser(obj, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        //metodos relacionados a eventos
        public JsonResult Evento()
        {
            List<EVENTO> olistaevent = new List<EVENTO>();
            olistaevent = new CNEVENTO().Evento();
            return Json(new { data = olistaevent }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EventoPendiente() {
            List<EVENTO> olista = new List<EVENTO>();
            olista = new CNEVENTO().EventPendin();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddingEvent(EVENTO obj)
        {
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().ADDEVENT(obj, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult CambiarAactivo(Miembro obj)
        {
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNMIEMBRO().Cambiar_estado_activo(obj, out mensaje);

          
            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);

        }
        public JsonResult deleteevent(EVENTO obj)
        {
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNEVENTO().eliminarevento(obj, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

    }
}