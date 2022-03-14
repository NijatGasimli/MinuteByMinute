using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Data.Utilities
{
   public class EmailHelper
    {

        public bool SendEmail(string userEmail, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("nijatqasimov200@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("nijatqasimov200@gmail.com", "ztittvtonhzonayx");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
}
