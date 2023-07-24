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
        public List<ReportEvent> Repvento(string FI, string FF, string USER)
        {
            return ONJEVENTO.ReportEvent(FI,FF,USER);
        }

        public List<EVENTO> EventPendin()
        {
            return ONJEVENTO.listarP();
        }
        public int ADDEVENT(EVENTO obj, Miembro obj1, out string mensaje)
        {
            obj.Id_catalogo = 0;
            obj.Id_estado = 0;
            obj.Id_evento_estado = 0;
            return ONJEVENTO.AddEvent(obj,obj1, out mensaje);
        }


        public int eliminarevento(EVENTO obj, out string mensaje)
        {
            return ONJEVENTO.deleteEvent(obj, out mensaje);
        }

        public int agregarasis(Asistente OBJ, out string mensaje)
        {
            return ONJEVENTO.Caddasistencia(OBJ, out mensaje);
        }

        public List<Asistente> catalogA(int Idevento, out string mensaje)
        {
            return ONJEVENTO.Ccatalogasis(Idevento, out mensaje);
        }

        public int Dltasis(string Nombre,int eventoid, out string mensaje)
        {
            return ONJEVENTO.Deleteasis(Nombre, eventoid, out mensaje);
        }

        public int MODevent(EVENTO OBJ, out string mensaje)
        {
            return ONJEVENTO.modEVENT(OBJ, out mensaje);
        }
        public int Aevent(int eventoid, out string mensaje)
        {
            return ONJEVENTO.APevent(eventoid, out mensaje);
        }
        public int DescartarE(int eventoid, out string mensaje)
        {
            return ONJEVENTO.Desevent(eventoid, out mensaje);
        }
        
    }
}
