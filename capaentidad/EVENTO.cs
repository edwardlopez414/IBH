﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class EVENTO
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string LugarEvento { get; set; }
        public char Transporte { get; set; }
        public string State { get; set; }
        public string Descripcion { get; set; }

        public int Id_estado { get; set; }
        public int Id_evento_estado { get; set; }
        public int Id_catalogo { get; set; }

    }
}
