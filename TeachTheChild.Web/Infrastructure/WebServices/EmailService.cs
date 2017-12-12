namespace TeachTheChild.Web.Infrastructure.WebServices
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using TeachTheChild.Web.Infrastructure.Constants;

    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = false;
                    mailMessage.From = new MailAddress(WebConstants.AppEmail);
                    mailMessage.To.Add(new MailAddress(email));
                    using (var smtp = new SmtpClient(WebConstants.GmailHost))
                    {
                        var credentials = new NetworkCredential(this.configuration["gmaillUser"], this.configuration["gmailPass"]);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = credentials;
                        smtp.EnableSsl = true;

                        await smtp.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
