using capaentidad;
using capanegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPAADMIN.Areas.CAPAUSER.Controllers
{
    public class HomeuserController : Controller
    {
        // GET: CAPAUSER/Homeuser
        public ActionResult Index()
        {
            List<EVENTO> EVENTP = new List<EVENTO>();

            using (SqlConnection oconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString()))
            {
                SqlCommand actual = new SqlCommand("actualizar_status", oconexion);
                oconexion.Open();
                actual.ExecuteNonQuery();
            }
            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString()))
                {
                    string query = "SELECT * FROM IBHPROC.dbo.EVENTO E INNER JOIN IBHPROC.dbo.estado_evento S ON E.IdEvento = S.Id_evento_estado";
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
                                Transporte = Convert.ToChar(rdr["Transporte"]),
                                Id_catalogo =Convert.ToInt32(rdr["Id_catalogo"])
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(EVENTP);
        }

        public ActionResult Setting()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult login()
        {
            return RedirectToAction("Index", "Login", new { area = "" });
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

        public JsonResult addasistencia2(string correo, Preregistro preregistro)
        {

            List<Miembro> MB = MIEMBROS(correo.TrimEnd());

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

        public List<Miembro> MIEMBROS(string correo)
        {
            
            List<Miembro> oLista = new List<Miembro>();
            oLista = new CNMIEMBRO().Miembrocorreo(correo.TrimEnd());

            return oLista;
        }

        public JsonResult  MIEMBROSemail(string correo)
        {

            List<Miembro> oLista = new List<Miembro>();
            oLista = new CNMIEMBRO().Miembrocorreo(correo.TrimEnd());

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModuserBD(Miembro obj)
        {
            object resultado;
            string mensaje = String.Empty;

            resultado = new CNMIEMBRO().Moduser(obj, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}