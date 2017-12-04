﻿namespace TeachTheChild.Services.Implementations
{
    using System.Collections.Generic;
    using AutoMapper;

    using TeachTheChild.Services.Contracts;
    using TeachTheChild.Services.Models.Users;
    using TeachTheChild.Web.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

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