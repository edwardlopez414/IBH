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

                    string sql = "SELECT * FROM IBPRO.dbo.EVENTO";
                    
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
                                    Transporte = Convert.ToChar(reader["Transporte"])

                            });
                        }
                    }
                    }
            }catch(Exception ex) { evento = new List<EVENTO>(); }

            return evento;

        }
    }
}
