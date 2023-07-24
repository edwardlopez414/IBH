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

        public List<Miembro> Miembro(string cedula ="")
        {
            if (cedula != "") {

                return objmiebro.listar_por_parametro(cedula);
            }
            else 
            return objmiebro.listar();
        }
        public int Cambiar_estado_activo(Miembro obj, out string mensaje)
        {        
            return objmiebro.Cambiar_estado_activo(obj, out mensaje);
        }
        public int Cambiar_estado_inactivo(Miembro obj, out string mensaje)
        {
            return objmiebro.Cambiar_estado_inactivo(obj, out mensaje);
        }

        public int AddUser(Miembro obj, out string mensaje)
        {
            string cl = Cnrecursos.GenerarClave();
            string asunto = "Clave autogenerada";
            string mensaje_correo = "<h3>Su contraseña fue generada correctamente</h3></br><p>Su contraseña para acceder es : !clave!</p>";
            mensaje_correo = mensaje_correo.Replace("!clave!", cl);
           

            bool respuesta = Cnrecursos.EnviarCorreo(obj.Email,asunto,mensaje_correo);

            if (respuesta) { obj.clave = Cnrecursos.ConvertirSha256(cl); return objmiebro.agregar_Miembro(obj, out mensaje); }
            else 
            {
            mensaje = "No se puede mandar el correo";
                return  0;
           }

            
        }

        public int Moduser(Miembro obj, out string mensaje)
        {
            return objmiebro.Moduser(obj, out mensaje);
        }

        public bool cambiarClave(int idUsuario, string nuevaClave, int restablecer,out string mensaje, string email = "" )
        {


            if (restablecer == 0)
            {             
                nuevaClave = Cnrecursos.ConvertirSha256(nuevaClave);
                return objmiebro.CambiarClave2(idUsuario, nuevaClave, restablecer, out mensaje);
            }
            else
            {
                nuevaClave = Cnrecursos.GenerarClave();            
                string asunto = "Clave Reestablecida";
                string mensaje_correo = "<h3>Su contraseña fue reestablecida correctamente</h3></br><p>Su contraseña para acceder es : !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", nuevaClave);
                bool respuesta = Cnrecursos.EnviarCorreo(email, asunto, mensaje_correo);
                nuevaClave = Cnrecursos.ConvertirSha256(nuevaClave);
                if (respuesta)
                {                  
                    return objmiebro.CambiarClave2(idUsuario, nuevaClave, restablecer, out mensaje);
                }
                else
                {
                    mensaje = "No se puede mandar el correo";
                    return false;
                }

            }
            

        }

    }
}
