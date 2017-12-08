namespace TeachTheChild.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;

    using TeachTheChild.Data;
    using TeachTheChild.Services.Contracts;
    using TeachTheChild.Services.Models.Users;

    public class UsersService : IUsersService
    {
        private readonly TeachTheChildDbContext dbContext;

        public UsersService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UserServiceModel> GetAll()
        {
            var users = this.dbContext
                .Users
                .ProjectTo<UserServiceModel>()
                .ToList();

            return users;
        }
    }
}
