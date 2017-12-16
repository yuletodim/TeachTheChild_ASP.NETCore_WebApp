namespace TeachTheChild.Services.Admin.Models.Users
{
    using Data.Models;
    using Common.Mappings;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System;

    public class UserAdminServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
