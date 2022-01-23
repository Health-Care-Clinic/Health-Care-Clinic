using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;
using MimeKit;

namespace Hospital.Tendering.Service
{
    public class MailService
    {
        public void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("fishingbookernsm@gmail.com");
                mail.To.Add("petrovic.ma9@gmail.com");
                mail.Subject = "Hospital Tender";
                mail.Body = "Vasa ponuda za tender je izabrana.";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("fishingbookernsm@gmail.com", "ninasaramarija123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
            }
        }
    }
}
