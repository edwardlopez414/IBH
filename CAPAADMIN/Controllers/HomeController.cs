using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaentidad;
using capanegocio;
using System.Configuration;

namespace CAPAADMIN.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult reporteevento()
        {
            return View();
        }
        // vistas relacioadas a usuarios capa admin
        public ActionResult Cataloguser()
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
        public ActionResult error()
        {
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
        public JsonResult AddingEvent(EVENTO obj )
        {
            Miembro miembro = new Miembro();
            miembro = new CNMIEMBRO().Miembro().Where(u => u.Email.TrimEnd() == obj.PARAN1.TrimEnd()).FirstOrDefault();
            object resultado;
            string mensaje = String.Empty;
            resultado = new CNEVENTO().ADDEVENT(obj, miembro, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CambiarAactivo(Miembro obj)
        {
            object resultado;
            string mensaje = String.Empty;
            resultado = new CNMIEMBRO().Cambiar_estado_activo(obj, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CambiarAinactivo(Miembro obj)
        {
            object resultado;
            string mensaje = String.Empty;
            resultado = new CNMIEMBRO().Cambiar_estado_inactivo(obj, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deleteevent(EVENTO obj)
        {
            object resultado;
            string mensaje = String.Empty;
            resultado = new CNEVENTO().eliminarevento(obj, out mensaje);
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getinfomes(int mes = 0)
        {
              List  <info >IF = new List<info>();
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString()))
                    {

                    string sql = "\tSELECT \n    YEAR(FECHA) AS Anio,\n    FORMAT(FECHA, 'MMMM', 'es-ES') AS Mes,\n    COUNT(IdEvento) AS NumeroEventos\nFROM \n    EVENTO\nGROUP BY \n    YEAR(FECHA),\n    MONTH(FECHA),\n    FORMAT(FECHA, 'MMMM', 'es-ES')\nORDER BY \n    YEAR(FECHA),\n    MONTH(FECHA);";
                    Console.WriteLine(sql);
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                            IF.Add(new info() {
                             NumeroEventos = Convert.ToInt32(reader["NumeroEventos"]),
                             Mes = reader["Mes"].ToString()
                            });
                                       
                            }
                        return Json(IF, JsonRequestBehavior.AllowGet);
                    }
                    }
                }
                catch (Exception ex)
                {
                return Json(IF);
                }

        }

        public JsonResult getinfomesASIS(int mes = 0)
        {
            List<info> IF = new List<info>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString()))
                {

                    string sql = "\tSelect\n\tYEAR(FECHA) AS Anio,\n    FORMAT(FECHA, 'MMMM', 'es-ES') AS Mes,\n    COUNT(A.IdAsistente) AS Asistentes from ASISTENTE A\n\tInner Join EVENTO B\n\tON A.IdEvento = B.IdEvento\n\tGROUP BY \n    YEAR(FECHA),\n    MONTH(FECHA),\n    FORMAT(FECHA, 'MMMM', 'es-ES')\nORDER BY \n    YEAR(FECHA),\n    MONTH(FECHA);";
                    Console.WriteLine(sql);
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            IF.Add(new info()
                            {
                                Asistentes = Convert.ToInt32(reader["NumeroEventos"]),
                                Mes = reader["Mes"].ToString()
                            });

                        }
                        return Json(IF, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(IF);
            }

        }
        public class info {
            public string Anio { get; set; }
            public string Mes { get; set; }
            public int NumeroEventos{ get; set; }
            public int Asistentes { get; set; }
        }
    }
}