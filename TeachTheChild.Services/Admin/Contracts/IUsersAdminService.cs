namespace TeachTheChild.Services.Admin.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Admin.Models.Users;

    public interface IUsersAdminService
    {
        Task<IEnumerable<UserAdminServiceModel>> GetAllWithPaging(int page = 1);

        Task<int> GetTotalCountAsync();
    }
}
