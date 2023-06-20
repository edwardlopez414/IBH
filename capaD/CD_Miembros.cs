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
                    string query = "select * from IBPRO.dbo.Datos_usuario A inner join IBPRO.dbo.login_usuario B on A.Id_Usuario = B.Id_usuario";

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
                                activo = Convert.ToInt32(rdr["activo"])
                            });
                        }
                    }
                }

            }catch (Exception ex) { 
                miembros = new List<Miembro>(); 
            }

            return miembros;
        }
    }
}
