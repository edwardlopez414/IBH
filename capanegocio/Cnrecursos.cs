using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace capanegocio
{
    public class Cnrecursos
    {        
        public static string GenerarClave() => Guid.NewGuid().ToString("N").Substring(0, 6);
        public static string ConvertirSha256(string contrasena)
        { 
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            { 
            
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(contrasena));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();   
            }
        
        }

        public static bool EnviarCorreo(string correo,string asunto,string mensaje) 
        {

            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();

                mail.To.Add(correo);
                mail.From = new MailAddress("ibhorebcommunity@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smpt = new SmtpClient()
                {
                    Credentials = new NetworkCredential("ibhorebcommunity@gmail.com", "awcqrkdjstyzxwkd"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                smpt.Send(mail);
                result = true;
            }
            catch (Exception e)
            {

                throw;
            }

        
            return result;
        }
    }
}
