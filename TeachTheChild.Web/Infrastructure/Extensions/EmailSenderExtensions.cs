namespace TeachTheChild.Web.Infrastructure.Extensions
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using TeachTheChild.Web.Infrastructure.WebServices;

    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailService emailService, string email, string link)
        {
            return emailService.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
