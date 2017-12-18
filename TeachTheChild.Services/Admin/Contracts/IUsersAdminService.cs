namespace TeachTheChild.Services.Admin.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Admin.Models.Users;

    public interface IUsersAdminService
    {
        IEnumerable<UserAdminServiceModel> GetFilteredPortion(
            int length,
            int start,
            string sortCol,
            string sortDir,
            string search,
            out int count);

        Task<int> GetTotalCountAsync();
    }
}
