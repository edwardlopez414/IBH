using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Preregistro
    {
        public string Descripcion { get; set; }
        public string medicamento { get; set; }
        public string dosis { get; set; }
        public string contacto_emergencias { get; set; }
        public string telefono  { get; set; }
        public int id_user { get; set; }
        public int id_evento { get; set; }    
    }
}
