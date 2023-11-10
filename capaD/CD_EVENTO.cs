using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidad;
using System.Data.SqlClient;
using System.Data;
using System.Security.Claims;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace capaD
{
    public class CD_EVENTO
    {
        public List<EVENTO> listar()
        {
            List<EVENTO> evento = new List<EVENTO>();

            try { 
                using (SqlConnection conn = new SqlConnection(Conexion.cn)) {

                    string sql = "SELECT * FROM IBHPROC.dbo.EVENTO A INNER JOIN IBHPROC.dbo.estado_evento B on A.IdEvento = B.Id_evento_estado order by 1 desc";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                    {
                        SqlCommand actual = new SqlCommand("actualizar_status", oconexion);
                        oconexion.Open();
                        actual.ExecuteNonQuery();
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            evento.Add(new EVENTO() { 
                                    IdEvento = Convert.ToInt32(reader["IdEvento"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Fecha = reader["Fecha"].ToString(),
                                    LugarEvento = reader["LugarEvento"].ToString(),
                                    Transporte = Convert.ToChar(reader["Transporte"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    estado = Convert.ToInt32(reader["Id_catalogo"])

                            });
                        }
                      
                         
                     }
                }
            }catch(Exception ex) { evento = new List<EVENTO>(); }

            return evento;

        }
        public List<EVENTO> listarP()
        {
            List<EVENTO> evento = new List<EVENTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.cn))
                {

                    string sql = "select TOP 3 A.IdEvento,A.Nombre,A.Fecha,A.LugarEvento,A.Transporte,C.data_catalog AS States from IBHPROC.DBO.EVENTO A INNER JOIN IBHPROC.dbo.estado_evento B ON B.Id_evento_estado = A.IdEvento INNER JOIN IBHPROC.dbo.Catalogo_estado C ON B.Id_Catalogo = C.Id_Catalogo_estado";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.Text;


                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            evento.Add(new EVENTO()
                            {
                                IdEvento = Convert.ToInt32(reader["IdEvento"]),
                                Nombre = reader["Nombre"].ToString(),
                                Fecha = reader["Fecha"].ToString(),
                                LugarEvento = reader["LugarEvento"].ToString(),
                                Transporte = Convert.ToChar(reader["Transporte"]),
                                State = reader["States"].ToString(),
                                
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { evento = new List<EVENTO>(); }

            return evento;

        }
        
        public List<ReportEvent> ReportEvent(string fechai, string fechaf,string Nombre, int estado)
        {
            List<ReportEvent> evento = new List<ReportEvent>();
            fechai += " 00:00:00.000";
            fechaf += " 00:00:00.000";
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.cn))
                {

                    string sql = "select * from EVENTO A inner join dbo.estado_evento B on A.IdEvento = B.Id_evento_estado where B.Id_catalogo = "+estado+" ANd A.Fecha between '"+fechai+"' and '"+fechaf+"' and Nombre like '%"+Nombre+"%'";
;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string readestado = reader["Id_catalogo"].ToString();
                            if (readestado == "4") {
                             readestado="SIN APROBAR";
                            }else if (readestado == "2") {
                                readestado = "APROBADO";
                            }else if(readestado == "3") { readestado = "RECHAZADO";
                            }else { readestado = "COMPLETADO"; }
                                evento.Add(new ReportEvent()
                            {
                                IdEvento = Convert.ToInt32(reader["IdEvento"]),
                                Nombre = reader["Nombre"].ToString(),
                                Fecha = reader["Fecha"].ToString(),
                                LugarEvento = reader["LugarEvento"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                estado = readestado,
                               
                                });
                        }
                    }
                }
            }
            catch (Exception ex) { evento = new List<ReportEvent>(); }

            return evento;

        }

        public List<ReportAsistent> ReportAsistant(string fechai, string fechaf, string user, int rol)
        {
            List<ReportAsistent> evento = new List<ReportAsistent>();
            fechai += " 00:00:00.000";
            fechaf += " 00:00:00.000";
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.cn))
                {

                    string sql = "select * from IBHPROC.dbo.ASISTENTE A INNER JOIN IBHPROC.dbo.EVENTO B ON A.IdEvento = B.IdEvento Inner Join user_event_rol C on C.id_user = A.IdUsuario Inner join rol_event D on C.id_rol_event = D.id_rol_evento WHERE  B.Fecha between '" + fechai + "'and'" + fechaf + "'AND A.Nombre_completo like '%" + user + "%' and B.Nombre like '%%'  and D.id_rol_evento = "+rol+"";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.Text;



                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            evento.Add(new ReportAsistent()
                            {
                                IdAsistente = Convert.ToInt32(reader["IdAsistente"]),
                                IdEvento = Convert.ToInt32(reader["IdEvento"]),
                                Nombre_completo = reader["Nombre_completo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Fecha = reader["Fecha"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                TipoAsistente = reader["TipoAsistente"].ToString(),
                                rol_evento = reader["rol_evento"].ToString(),

                            });
                        }
                    }
                }
            }
            catch (Exception ex) { evento = new List<ReportAsistent>(); }

            return evento;
        }

        public List<ReportMiembro> ReporteMiembro(string fechai, string fechaf, string user,int edad = 1,string sexo = "F",int rol = 1)
        {
            List<ReportMiembro> evento = new List<ReportMiembro>();
            fechai += " 00:00:00.000";
            fechaf += " 00:00:00.000";
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.cn))
                {

                    string sql = "select * from Login_usuario A inner join Datos_usuario B on A.id_usuario = B.Id_Usuario where B.Fecha_bautismo between '"+fechai+"' and '"+fechaf+"' and A.usuario like '%"+user+"%' and B.edad >= "+edad+" and B.Sexo like '%"+sexo+ "%'AND A.Id_rol = "+rol+"";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            evento.Add(new ReportMiembro()
                            {
                                Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]),
                                usuario = reader["usuario"].ToString(),
                                Nombre_Completo = reader["Nombre_Completo"].ToString(),
                                restablecer = Convert.ToInt32(reader["restablecer"]),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                Direccion = reader["Direccion"].ToString(),
                                Nro_contacto = reader["Nro_contacto"].ToString(),
                                Email = reader["Email"].ToString(),
                                Fecha_bautismo = reader["Fecha_bautismo"].ToString(),
                                Fecha_ingreso = reader["Fecha_ingreso"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { evento = new List<ReportMiembro>(); }

            return evento;
        }

        public int AddEvent(EVENTO obj,Miembro obj1, out string mensaje)
        {
            string rol ;

            if (obj1.Id_rol == 1)
            {
                rol = "ADMINISTRADOR";
            }
            else if (obj1.Id_rol == 2)
            {
                rol = "MIEMBRO";
            }
            else {
                rol = "LIDER DE JOVENES";
            }

            int intreturn = 0;

            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_INSERTAR_EVENTO", oconexion);
                    
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("LugarEvento", obj.LugarEvento);
                    cmd.Parameters.AddWithValue("Trasnporte", obj.Transporte);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Id_estado", obj.Id_estado);
                    cmd.Parameters.AddWithValue("Id_evento_estado", obj.Id_evento_estado);
                    cmd.Parameters.AddWithValue("Id_catalogo", obj.Id_catalogo);
                    cmd.Parameters.AddWithValue("IdMiembro", obj1.Id_rol);
                    cmd.Parameters.Add("mesaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }

        public int deleteEvent(EVENTO obj, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_delete_event_simple", oconexion);

                    cmd.Parameters.AddWithValue("IdEvento", obj.IdEvento);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }

        public int Caddasistencia(Asistente obj, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Asistentadd", oconexion);
                    obj.IdAsistente = 0;
                    cmd.Parameters.AddWithValue("IdEvento", obj.IdEvento);
                    cmd.Parameters.AddWithValue("TipoAsistente", obj.TipoAsistente);
                    cmd.Parameters.AddWithValue("Nombre_Completo", obj.Nombre_Completo);
                    cmd.Parameters.AddWithValue("IdAsistente", obj.IdAsistente);

                    cmd.Parameters.AddWithValue("edad", obj.edad);
                    cmd.Parameters.AddWithValue("direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("Nro_contacto", obj.contacto);
                    cmd.Parameters.AddWithValue("Cedula", obj.cedula);
                    cmd.Parameters.AddWithValue("id_rol_event", obj.id_rol_event);
                    
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }
        //addasis capa user 
        public int Caddasistencia2(Asistente obj, out string mensaje,  Preregistro preregistro)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Asistentadd2", oconexion);
                    obj.IdAsistente = 0;
                    cmd.Parameters.AddWithValue("IdEvento", obj.IdEvento);
                    cmd.Parameters.AddWithValue("TipoAsistente", obj.TipoAsistente);
                    cmd.Parameters.AddWithValue("Nombre_Completo", obj.Nombre_Completo);
                    cmd.Parameters.AddWithValue("IdAsistente", obj.IdAsistente);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);

                    //preregistros
                    cmd.Parameters.AddWithValue("Descripcion", preregistro.Descripcion);
                    cmd.Parameters.AddWithValue("medicamentos", preregistro.Descripcion);
                    cmd.Parameters.AddWithValue("dosis", preregistro.dosis);
                    cmd.Parameters.AddWithValue("contacto_emergencias", preregistro.contacto_emergencias);
                    cmd.Parameters.AddWithValue("telefono", preregistro.telefono);
                    cmd.Parameters.AddWithValue("id_user", preregistro.id_user);
                    cmd.Parameters.AddWithValue("id_evento", preregistro.id_evento);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }

        public List<Asistente> Ccatalogasis (int Idevento, out string mensaje)
        {
            mensaje = string.Empty;
            List<Asistente> miembros = new List<Asistente>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select DISTINCT A.Nombre_Completo, B.Nombre, A.TipoAsistente,B.IdEvento, A.statuspreregistro from ASISTENTE A  left JOIN EVENTO B ON A.IdEvento = B.IdEvento right join Datos_usuario C ON A.Nombre_completo = C.Nombre_Completo where B.IdEvento = "+Idevento+" AND A.IdUsuario is not null and C.Email = 'emaildeprueba'";

                    SqlCommand cmd = new SqlCommand(query, oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            miembros.Add(new Asistente()
                            {
                                IdEvento = Convert.ToInt32(rdr["IdEvento"]),
                                Nombre = rdr["Nombre"].ToString(),
                                TipoAsistente = Convert.ToChar(rdr["TipoAsistente"].ToString()),
                                Nombre_Completo = rdr["Nombre_Completo"].ToString(),
                                status = Convert.ToInt32(rdr["statuspreregistro"])
                            });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                miembros = new List<Asistente>();
                mensaje = ex.Message;
            }

            return miembros;
        }

        public int Deleteasis( string nombre,int eventoid, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("deleteasistant", oconexion);
                    cmd.Parameters.AddWithValue("Nombre_Completo", nombre);
                    cmd.Parameters.AddWithValue("IdEvento", eventoid);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }
        public int modEVENT(EVENTO obj, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_mod_event", oconexion);
                    cmd.Parameters.AddWithValue("IdEvento", obj.IdEvento);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("LugarEvento", obj.LugarEvento);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Transporte", obj.Transporte);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }

        
               public int APevent(int eventoid, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_aprovatedEvent", oconexion);
                    cmd.Parameters.AddWithValue("IdEvento", eventoid);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }
        public int Desevent(int eventoid, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_CancelarEvent", oconexion);
                    cmd.Parameters.AddWithValue("IdEvento", eventoid);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

            return intreturn;
        }


    }
}
