namespace TeachTheChild.Services.Admin.Contracts
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Admin.Models.Users;

    public interface IUsersAdminService
    {
        IEnumerable<UserAdminServiceModel> GetAll();
    }
}
