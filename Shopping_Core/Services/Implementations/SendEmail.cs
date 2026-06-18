using System.Net.Mail;
using Shopping_Core.Services.Interfaces;

namespace Shopping_Core.Services.Implementations
{
    public class SendEmail : IMailSender
    {
        public void Send(string to, string subject, string body)
        {
            var defaultEmail = "db.vahid1373@gmail.com";

            var mail = new MailMessage();

            var smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(defaultEmail, "فروشگاه انگولار");

            mail.To.Add(to);

            mail.Subject = subject;

            mail.Body = body;

            mail.IsBodyHtml = true;

            smtpServer.Port = 587;

            var password = "ghve dpev mvyx rszb";

            smtpServer.Credentials = new System.Net.NetworkCredential(defaultEmail, password);

            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
        }
    }
}

