namespace TeachTheChild.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Common;
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

        public async Task<IEnumerable<UserAdminServiceModel>> GetAllWithPaging(int page = 1)
        {
            var users = await this.dbContext
                .Users
                //.OrderByDescending(u => u.CreatedOn)
                //.Skip((page - 1) * GlobalConstants.PageSize)
                //.Take(GlobalConstants.PageSize)
                .ToListAsync();

            var usersModel = new List<UserAdminServiceModel>();
            users.AsParallel()
                .ForAll(async u => 
                {
                    usersModel.Add(new UserAdminServiceModel
                    {
                        Id = u.Id,
                        Username = u.UserName,
                        Name = u.Name,
                        Email = u.Email,
                        CreatedOn = u.CreatedOn
                        //Roles = await this.userManager.GetRolesAsync(u)
                    });
                    
                });

            return usersModel;
        }

        public async Task<int> GetTotalCountAsync()
            => await this.dbContext
                .Users
                .CountAsync();
    }
}
