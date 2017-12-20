namespace TeachTheChild.Services.Admin.Implementations
{
    using AutoMapper;
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
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IMapper mapper;

        public UsersAdminService(
            TeachTheChildDbContext dbContext, 
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public IEnumerable<UserAdminServiceModel> GetFilteredPortion(
            string role,
            int length,
            int start,
            string sortCol,
            string sortDir,
            string search,
            out int count)
        {
            var users = this.dbContext.Users.AsQueryable();

            if (role != null)
            {
                users = this.userManager.GetUsersInRoleAsync(role).Result.AsQueryable();
            }

            users = users
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

            return usersModel;
        }


        public async Task<UserDetailsAdminModel> GetByIdAsync(string id)
        {
            var user = await this.dbContext
                .Users
                .Include(u => u.Country)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            var userRoles = await this.userManager.GetRolesAsync(user);

            var userModel = this.mapper.Map<UserDetailsAdminModel>(user);
            userModel.Roles = string.Join(", ", userRoles);

            return userModel;
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
            => await this.roleManager.Roles.ToListAsync();

        public async Task<bool> AddUserToRoleAsync(string userId, string role)
        {
            var roleExist = await this.roleManager.RoleExistsAsync(role);
            var user = await this.userManager.FindByIdAsync(userId);
            var userExist = user != null;
            var isUserInRole = await this.userManager.IsInRoleAsync(user, role);
            if (!roleExist || !userExist || isUserInRole)
            {
                return false;
            }

            await this.userManager.AddToRoleAsync(user, role);

            return true;
        }
    }
}
