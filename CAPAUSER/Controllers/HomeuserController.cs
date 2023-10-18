using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaentidad;
using capanegocio;
using System.Configuration;
using System.Net.Mime;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;

namespace CAPAUSER.Controllers
{
    public class HomeuserController : Controller
    {
        public ActionResult Index()
        {
            List<EVENTO> EVENTP = new List<EVENTO>();
      

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString())) {
                    string query = "SELECT * FROM IBHPROC.dbo.EVENTO E INNER JOIN IBHPROC.dbo.estado_evento S ON E.IdEvento = S.Id_evento_estado  where S.Id_catalogo = 2";
                    SqlCommand cmd = new SqlCommand(query, oconexion);

                    cmd.CommandType = System.Data.CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader()) { 
                        while (rdr.Read())
                        {
                            EVENTP.Add(new EVENTO
                            {
                                Nombre = rdr["Nombre"].ToString(),
                                Fecha = rdr["Fecha"].ToString(),
                                LugarEvento = rdr["LugarEvento"].ToString(),
                                Descripcion = rdr["Descripcion"].ToString(),
                                Transporte = Convert.ToChar(rdr["Transporte"])

                            });

                        }
                    }
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return View(EVENTP);
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

        public List<EVENTO> detailevent()
        {
            List<EVENTO> EVENTP = new List<EVENTO>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString()))
                {
                    string query = "SELECT * FROM IBHPROC.dbo.EVENTO E INNER JOIN IBPRO.dbo.estado_evento S ON E.IdEvento = S.Id_evento_estado  where S.Id_catalogo = 2";
                    SqlCommand cmd = new SqlCommand(query, oconexion);

                    cmd.CommandType = System.Data.CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            EVENTP.Add(new EVENTO
                            {
                                Nombre = rdr["Nombre"].ToString(),
                                Fecha = rdr["Fecha"].ToString(),
                                LugarEvento = rdr["LugarEvento"].ToString(),
                                Descripcion = rdr["Descripcion"].ToString(),
                                Transporte = Convert.ToChar(rdr["Transporte"])

                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return EVENTP;

        }

        public JsonResult addasistencia2(string correo, Preregistro preregistro )
        {

            List< Miembro> MB = MIEMBROS(correo);

            Asistente OBJ = new Asistente();
            OBJ.IdAsistente = 0;
            OBJ.Nombre_Completo = MB[0].Nombre_Completo;
            OBJ.IdUsuario = MB[0].Id_Usuario;
            OBJ.IdEvento = Convert.ToInt32(preregistro.id_evento);
            OBJ.TipoAsistente = 'M';
         
            object resultado;
            string mensaje = String.Empty;
            resultado = new CNEVENTO().agregarasis2(OBJ, out mensaje, preregistro);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public List< Miembro > MIEMBROS(string correo )
        {

            List <Miembro> oLista = new List<Miembro> ();
            oLista = new CNMIEMBRO().Miembrocorreo(correo);

            return oLista;
        }

    }
}