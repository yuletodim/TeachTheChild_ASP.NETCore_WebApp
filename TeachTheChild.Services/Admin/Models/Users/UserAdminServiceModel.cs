namespace TeachTheChild.Services.Admin.Models.Users
{
    using Common.Mappings;
    using Data.Models;
    using System;

    public class UserAdminServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
