namespace TeachTheChild.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;

    using TeachTheChild.Data;
    using TeachTheChild.Services.Admin.Contracts;
    using TeachTheChild.Services.Admin.Models.Users;

    public class UsersAdminService : IUsersAdminService
    {
        private readonly TeachTheChildDbContext dbContext;

        public UsersAdminService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UserAdminServiceModel> GetAll()
        {
            var users = this.dbContext
                .Users
                .ProjectTo<UserAdminServiceModel>()
                .ToList();

            return users;
        }
    }
}
