using AorangiPeak.Common.Config;
using System.Net.Mail;

namespace AorangiPeak.Common.Email
{
    public class DefaultEmailService : IEmail
    {
        private IConfiguration config;

        public DefaultEmailService()
        {
            config = new ConfigFromXML();
        }

        public void SendEmail(string to, string subject, string message)
        {
            MailMessage mm = new MailMessage(config.EmailFromAddress, to);
            mm.Subject = subject;
            mm.Body = message;
            Send(mm);
        }

        public void SendEmail(string to, string cc, string bcc, string subject, string message)
        {
            MailMessage mm = new MailMessage(config.EmailFromAddress, to);
            mm.CC.Add(cc);
            mm.Bcc.Add(bcc);
            mm.Subject = subject;
            mm.Body = message;
            mm.IsBodyHtml = true;
            Send(mm);
        }

        public void SendIndiviualEmailPerRecipient(string[] to, string subject, string message)
        {
            foreach (var t in to)
            {
                MailMessage mm = new MailMessage(config.EmailFromAddress, t);
                mm.Subject = subject;
                mm.Body = message;
                mm.IsBodyHtml = true;
                Send(mm);
            }
        }

        private void Send(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
}
