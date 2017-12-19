namespace TeachTheChild.Services.Admin.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Admin.Models.Users;

    public interface IUsersAdminService
    {
        IEnumerable<UserAdminServiceModel> GetFilteredPortion(
            string role,
            int length,
            int start,
            string sortCol,
            string sortDir,
            string search,
            out int count);

        Task<UserDetailsAdminModel> GetByIdAsync(string id);

        Task<IEnumerable<IdentityRole>> GetRolesAsync();

        Task<bool> AddUserToRoleAsync(string userId, string role);
    }
}
