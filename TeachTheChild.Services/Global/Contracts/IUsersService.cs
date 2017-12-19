namespace TeachTheChild.Services.Global.Contracts
{
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task EditUserDetailsAsync(string userId, string name, int countryId, int languageId);
    }
}
