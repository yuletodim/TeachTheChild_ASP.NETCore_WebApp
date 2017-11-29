namespace TeachTheChild.Services.Contracts
{
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
