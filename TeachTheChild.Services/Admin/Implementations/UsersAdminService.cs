namespace TeachTheChild.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Admin.Contracts;
    using TeachTheChild.Services.Admin.Models.Users;

    public class UsersAdminService : IUsersAdminService
    {
        private readonly TeachTheChildDbContext dbContext;
        private readonly UserManager<User> userManager;

        public UsersAdminService(TeachTheChildDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public IEnumerable<UserAdminServiceModel> GetFilteredPortion(
            int length,
            int start,
            string sortCol,
            string sortDir,
            string search,
            out int count)
        {
            var users = this.dbContext
                .Users
                .Where(u => search == null
                || u.UserName.ToLower().Contains(search.ToLower())
                || u.Email.ToLower().Contains(search.ToLower())
                || u.Name.ToLower().Contains(search.ToLower())
                || u.CreatedOn.ToString().ToLower().Contains(search.ToLower()));

            count = users.Count();

            var usersModel = users
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)
                    .ProjectTo<UserAdminServiceModel>()
                    .ToList();
            var usersIds = usersModel.Select(um => um.Id);
            var searchedUsers = users.Where(u => usersIds.Contains(u.Id)).ToList();

            searchedUsers.ForEach(async u =>
            {
                var roles = await this.userManager.GetRolesAsync(u);
                if (roles.Count > 0)
                {
                    var user = usersModel.FirstOrDefault(um => um.Id == u.Id);
                    user.Roles = string.Join(", ", roles);
                }
            });

            return usersModel;
        }

        public async Task<int> GetTotalCountAsync()
            => await this.dbContext
                .Users
                .CountAsync();
    }
}
