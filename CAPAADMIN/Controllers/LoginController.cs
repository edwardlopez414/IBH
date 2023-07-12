using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using capaentidad;
using capanegocio;

namespace CAPAADMIN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Viewpass()
        {
            return View();
        }
        public ActionResult restablecerpass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult restablecerpass(string email)
        {
            string pwd = Cnrecursos.GenerarClave();
            string clave = Cnrecursos.ConvertirSha256(pwd);
            Miembro miembro = new Miembro();

            miembro = new CNMIEMBRO().Miembro().Where(u => u.Email.TrimEnd() == email).FirstOrDefault();

            if (miembro == null)
            {
                ViewBag.error = "No se encontro usuario con ese correo";
                return View();
            }

            string mensaje = string.Empty;

            bool respuesta = new CNMIEMBRO().cambiarClave(miembro.Id_Usuario,clave,1,out mensaje,miembro.Email);

            if (respuesta)
            {
                ViewBag.error = null;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = mensaje;
                return View();
            }

           

        }

        [HttpPost]
        public ActionResult Index(string correo, string pwd)
        {
            string clave = Cnrecursos.ConvertirSha256(pwd);
            Miembro miembro = new Miembro();

            miembro = new CNMIEMBRO().Miembro().Where(u => u.Email.TrimEnd() == correo && u.clave == clave).FirstOrDefault();

            if (miembro == null)
            {
                ViewBag.error = "Credenciales Incorrectas";
                return View();
            }
            else {
                ViewBag.error = null;
                if (miembro.restablecer == 1) {
                    TempData["Id_Usuario"] = miembro.Id_Usuario;
                    return RedirectToAction("Viewpass", "Login");
                }
                FormsAuthentication.SetAuthCookie(miembro.Email, false);
                return RedirectToAction("Index", "Home");
                
               
            }

            

        }
        [HttpPost]
        public ActionResult Viewpass(string usuario,string actual,string clave,string confirmar)
        {
            Miembro miembro = new Miembro();
            miembro = new CNMIEMBRO().Miembro().Where(u => u.Id_Usuario == int.Parse(usuario)).FirstOrDefault();
            if (miembro.clave != Cnrecursos.ConvertirSha256(actual))
            {
                TempData["Id_Usuario"] = usuario;
                  ViewBag.error = "contraseña actual Incorrecta";
                return View();
            }
            else if (clave != confirmar)
            {
                TempData["Id_Usuario"] = usuario;
                ViewBag.error = "Las contraseñas no coinciden";
                return View();
            }
            ViewBag.error = null;
          
            string mensaje = string.Empty;
            bool res = new CNMIEMBRO().cambiarClave(int.Parse(usuario),clave,0,out mensaje);

            if (res) { 
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Id_Usuario"] = usuario;
                ViewBag.error = mensaje;
                return View();
            }
            return View();
        }
    }
}