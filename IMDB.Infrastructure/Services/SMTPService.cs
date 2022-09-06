using IMDB.Core.Applications.Common.Interfaces;
using System.Net.Mail;


namespace IMDB.Infrastructure.Services
{
    public class SMTPService: IMailSender
    {
        public void Send(string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("nika.melqadze@gmail.com");
            mail.Sender = new MailAddress("nika.melqadze@gmail.com");
            mail.To.Add("nika.melqadze@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = body;

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("nika.melqadze@gmail.com", "jhecsayxglacgdtf");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;

                smtp.Timeout = 30000;
                smtp.Send(mail);
            }
        }

    }
}
