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
                    string query = "select * from IBPRO.dbo.MIEMBRO";

                    SqlCommand cmd = new SqlCommand(query,oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using(SqlDataReader rdr = cmd.ExecuteReader()){
                        while( rdr.Read())
                        {
                            miembros.Add(new Miembro()
                            {
                                IdMiembro = Convert.ToInt32(rdr["IdMiembro"]),
                                PNombre = rdr["PNombre"].ToString(),
                                SNombre = rdr["SNombre"].ToString(),
                                Papellido = rdr["Papellido"].ToString(),
                                Sapellido = rdr["Sapellido"].ToString(),
                                Edad = Convert.ToInt32(rdr["Edad"]),
                                Telefono = rdr["Telefono"].ToString(),
                                Cargo = rdr["Cargo"].ToString(),
                                Direccion = rdr["Direccion"].ToString(),
                                Sexo = Convert.ToChar(rdr["Sexo"])
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
