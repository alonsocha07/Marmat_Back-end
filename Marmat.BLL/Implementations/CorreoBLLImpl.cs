using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Marmat.DML;

namespace Marmat.BLL.Implementations
{
    public class CorreoBLLImpl
    {
        public bool MandarCorreo(Catalogo correo)
        {


            string DireccionCorreo = "alonsoinvestigacion@outlook.com";
            string Contrasenia = "acc1234321";

            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(DireccionCorreo, Contrasenia);

            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                //Cambiar el correo al que guste hacer la prueba
                var mail = new MailMessage(DireccionCorreo, "achaves50564@ufide.ac.cr");
                mail.IsBodyHtml=true;
                mail.Subject = "Aplicacion Web Marmat: " + correo.NombreCondominio;
                mail.Body = correo.nombre +" "+ correo.apellidos + "  ha enviado información. <br/><br/>"
                   +"Correo: " +correo.correo+"<br/>Telefono: " + correo.numero+ "<br/><br/>Mensaje: " +correo.mensaje;

                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public bool MandarCorreoVisitas(CorreoVisitas correo)
        {


            string DireccionCorreo = "alonsoinvestigacion@outlook.com";
            string Contrasenia = "acc1234321";

            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(DireccionCorreo, Contrasenia);

            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                //Cambiar el correo al que guste hacer la prueba
                var mail = new MailMessage(DireccionCorreo, "estebanuro@gmail.com");
                mail.IsBodyHtml = true;
                mail.Subject = "Aviso de Visitas";
                mail.Body = "La Fecha: " + correo.Fecha + " estaran visitando las siguientes personas: " + correo.Comentario;

                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
