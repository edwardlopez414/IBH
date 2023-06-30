using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaD;
using capaentidad;
namespace capanegocio
{
    public class CNMIEMBRO
    {
        private CD_Miembros objmiebro = new CD_Miembros();

        public List<Miembro> Miembro(string cedula)
        {
            if (cedula != "") {

                return objmiebro.listar_por_parametro(cedula);
            }
            else 
            return objmiebro.listar();
        }


    }
}
