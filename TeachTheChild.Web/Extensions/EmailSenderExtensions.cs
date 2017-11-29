namespace TeachTheChild.Web.Services
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Contracts;

    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailService emailService, string email, string link)
        {
            return emailService.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
