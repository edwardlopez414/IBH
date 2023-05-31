using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaD;
using capaentidad;

namespace capanegocio
{
    public class CNEVENTO
    {
        private CD_EVENTO ONJEVENTO = new CD_EVENTO();
        public List<EVENTO> Evento()
        {
            return ONJEVENTO.listar();
        }

    }
}
