namespace TeachTheChild.Services.Contracts
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Models.Users;

    public interface IUsersService
    {
        IEnumerable<UserServiceModel> GetAll();
    }
}
