using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public string Asunto { get; set; }

        public EmailService()
        {

            server = new SmtpClient();
            server.Credentials = new NetworkCredential("grupo.6.appweb.sorteo@gmail.com", "xoly xovk shpo dmhc");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
            Asunto = "Soporte";


        }

        public void armarCorreo(string correo, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("grupo.6.appweb.sorteo@gmail.com");
            email.To.Add(correo);
            email.Subject = Asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1> Gracias por contactar al equipo de soporte!</h1> " +
                "<br> Vamos a informar ayudarte a solucionar los problemas ocasionados en la app... " +
                "<br>" + mensaje;
           
                
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
