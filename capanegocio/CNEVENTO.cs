﻿using System;
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

        public List<EVENTO> EventPendin()
        {
            return ONJEVENTO.listarP();
        }
        public int ADDEVENT(EVENTO obj, out string mensaje)
        {
            obj.Id_catalogo = 0;
            obj.Id_estado = 0;
            obj.Id_evento_estado = 0;
            return ONJEVENTO.AddEvent(obj, out mensaje);
        }
    }
}
