using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidad;
using System.Data.SqlClient;
using System.Data;

namespace capaD
{
    public class CD_EVENTO
    {
        public List<EVENTO> listar()
        {
            List<EVENTO> evento = new List<EVENTO>();

            try { 
                using (SqlConnection conn = new SqlConnection(Conexion.cn)) {

                    string sql = "SELECT * FROM IBPRO.dbo.EVENTO A INNER JOIN IBPRO.dbo.estado_evento B on A.IdEvento = B.Id_evento_estado order by 1 desc";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.Text;

                    

                    conn.Open();

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

                    string sql = "select TOP 3 A.IdEvento,A.Nombre,A.Fecha,A.LugarEvento,A.Transporte,C.data_catalog AS States from IBPRO.DBO.EVENTO A INNER JOIN IBPRO.dbo.estado_evento B ON B.Id_evento_estado = A.IdEvento INNER JOIN IBPRO.dbo.Catalogo_estado C ON B.Id_Catalogo = C.Id_Catalogo_estado";

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

        public int AddEvent(EVENTO obj, out string mensaje)
        {
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
                    string query = "SELECT * FROM IBPRO.dbo.ASISTENTE A inner join IBPRO.dbo.EVENTO B ON A.IdEvento= B.IdEvento where A.Idevento =" + Idevento;

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
        
    }
}
