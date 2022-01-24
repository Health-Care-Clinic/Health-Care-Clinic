using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Pharmacy.UrgentMedicines.Service
{
    public class MailService
    {
        public void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("pharmacypsw@gmail.com");
                mail.To.Add("fishingbookernsm@gmail.com");
                mail.Subject = "Urgent Medicine Procurement";
                mail.Body = "Successful urgent procurement!";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pharmacypsw@gmail.com", "apoteka123*");
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
