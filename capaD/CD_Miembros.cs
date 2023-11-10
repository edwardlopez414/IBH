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
    public class CD_Miembros
    {
        public List<Miembro> listar()
        {
            List < Miembro > miembros = new List <Miembro>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from IBHPROC.dbo.Datos_usuario A inner join IBHPROC.dbo.login_usuario B on A.Id_Usuario = B.Id_usuario";

                    SqlCommand cmd = new SqlCommand(query,oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using(SqlDataReader rdr = cmd.ExecuteReader()){
                        while( rdr.Read())
                        {
                            miembros.Add(new Miembro()
                            {
                                Direccion = rdr["Direccion"].ToString(),
                                Edad = Convert.ToInt32(rdr["Edad"]),
                                Email = rdr["Email"].ToString(),
                                Fecha_bautismo = rdr["Fecha_bautismo"].ToString(),
                                Fecha_ingreso = rdr["Fecha_ingreso"].ToString(),
                                Id_Usuario = Convert.ToInt32(rdr["Id_Usuario"]),
                                Nombre_Completo = rdr["Nombre_Completo"].ToString(),
                                Nro_contacto = rdr["Nro_contacto"].ToString(),
                                Sexo = rdr["Sexo"].ToString(),
                                activo = Convert.ToInt32(rdr["activo"]),
                                Cedula = rdr["Cedula"].ToString(),
                                clave = rdr["clave"].ToString(),
                                restablecer =Convert.ToInt32(rdr["restablecer"]),
                                Id_rol = Convert.ToInt32(rdr["Id_rol"])
                            });
                        }
                    }
                }

            }catch (Exception ex) { 
                miembros = new List<Miembro>(); 
            }

            return miembros;
        }

        public List<Miembro> listar_por_parametro( string cedula)
        {
            List < Miembro > miembros = new List<Miembro>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from IBHPROC.dbo.Datos_usuario A inner join IBHPROC.dbo.login_usuario B on A.Id_Usuario = B.Id_usuario where Cedula like '%" + cedula+"%'";

                   SqlCommand cmd = new SqlCommand(query, oconexion);

                   cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using(SqlDataReader rdr = cmd.ExecuteReader()){
                        while(rdr.Read())
                        {
                            miembros.Add(new Miembro()
        {
                                Direccion = rdr["Direccion"].ToString(),
                                Edad = Convert.ToInt32(rdr["Edad"]),
                                Email = rdr["Email"].ToString(),
                                Fecha_bautismo = rdr["Fecha_bautismo"].ToString(),
                                Fecha_ingreso = rdr["Fecha_ingreso"].ToString(),
                                Id_Usuario = Convert.ToInt32(rdr["Id_Usuario"]),
                                Nombre_Completo = rdr["Nombre_Completo"].ToString(),
                                Nro_contacto = rdr["Nro_contacto"].ToString(),
                                Sexo = rdr["Sexo"].ToString(),
                                activo = Convert.ToInt32(rdr["activo"]),
                                Cedula = rdr["Cedula"].ToString(),
                                usuario = rdr["usuario"].ToString()
                            });
                        }
}
                }

            }catch (Exception ex) {
    miembros = new List<Miembro>();
}

            return miembros;
        }

        public List<Miembro> listar_por_parametro_correo(string correo)
        {
            List<Miembro> miembros = new List<Miembro>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from IBHPROC.dbo.Datos_usuario A inner join IBHPROC.dbo.login_usuario B on A.Id_Usuario = B.Id_usuario where  A.Email = '"+correo +"'";

                    SqlCommand cmd = new SqlCommand(query, oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            miembros.Add(new Miembro()
                            {
                                Direccion = rdr["Direccion"].ToString(),
                                Edad = Convert.ToInt32(rdr["Edad"]),
                                Email = rdr["Email"].ToString(),
                                Fecha_bautismo = rdr["Fecha_bautismo"].ToString(),
                                Fecha_ingreso = rdr["Fecha_ingreso"].ToString(),
                                Id_Usuario = Convert.ToInt32(rdr["Id_Usuario"]),
                                Nombre_Completo = rdr["Nombre_Completo"].ToString(),
                                Nro_contacto = rdr["Nro_contacto"].ToString(),
                                Sexo = rdr["Sexo"].ToString(),
                                activo = Convert.ToInt32(rdr["activo"]),
                                Cedula = rdr["Cedula"].ToString(),
                                usuario = rdr["usuario"].ToString()
                            });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                miembros = new List<Miembro>();
            }

            return miembros;
        }

        public int Cambiar_estado_activo(Miembro obj, out string mensaje) { 
          int intreturn = 0;
          mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizar_estatus_activo", oconexion);
                    cmd.Parameters.AddWithValue("id_usuario", obj.Id_Usuario);
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,200).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("resultado",SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    intreturn = Convert.ToInt32(cmd.Parameters["resultado"].Value);

                }
            } catch (Exception ex)
            {
                intreturn = 0;
                mensaje = ex.Message;
            }

                return intreturn;
            }
        public int Cambiar_estado_inactivo(Miembro obj, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizar_estatus_inactivo", oconexion);
                    cmd.Parameters.AddWithValue("id_usuario", obj.Id_Usuario);
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


        public int agregar_Miembro(Miembro obj, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            obj.restablecer = 1;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_select", oconexion);
                    cmd.Parameters.AddWithValue("usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("edad", obj.Edad);
                    cmd.Parameters.AddWithValue("direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("contrasena", obj.contrasena);
                    cmd.Parameters.AddWithValue("activo", obj.activo);
                    cmd.Parameters.AddWithValue("restablecer", obj.restablecer);
                    cmd.Parameters.AddWithValue("Id_rol", obj.Id_rol);
                    cmd.Parameters.AddWithValue("clave", obj.clave);
                    cmd.Parameters.AddWithValue("email", obj.Email);
                    cmd.Parameters.AddWithValue("Fecha_buatismo", obj.Fecha_bautismo);
                    cmd.Parameters.AddWithValue("Fecha_ingreso", obj.Fecha_ingreso);
                    cmd.Parameters.AddWithValue("Nombre_Completo", obj.Nombre_Completo);
                    cmd.Parameters.AddWithValue("Nro_contacto", obj.Nro_contacto);
                    cmd.Parameters.AddWithValue("sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
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

        public int Moduser(Miembro obj, out string mensaje)
        {
            int intreturn = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizar_user", oconexion);
                    cmd.Parameters.AddWithValue("usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("edad", obj.Edad.ToString());
                    cmd.Parameters.AddWithValue("direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Id_rol", obj.Id_rol);
                    cmd.Parameters.AddWithValue("email", obj.Email);
                    cmd.Parameters.AddWithValue("Fecha_bautismo", Convert.ToDateTime(obj.Fecha_bautismo));
                    cmd.Parameters.AddWithValue("Fecha_ingreso", Convert.ToDateTime(obj.Fecha_ingreso));
                    cmd.Parameters.AddWithValue("Nombre_Completo", obj.Nombre_Completo);
                    cmd.Parameters.AddWithValue("Nro_contacto", obj.Nro_contacto.ToString());
                    cmd.Parameters.AddWithValue("sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("Id_Usuario", obj.Id_Usuario);
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
  
public bool CambiarClave2(int idUsuario, string nuevaClave, int restablecer, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE IBHPROC.dbo.login_usuario SET clave = @nuevaclave, restablecer = @restablecer WHERE id_usuario = @id", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.Parameters.AddWithValue("@nuevaclave", nuevaClave);
                        cmd.Parameters.AddWithValue("@restablecer", restablecer);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}


