namespace TeachTheChild.Services.Models.Users
{
    using Data.Models;
    using Common.Mappings;

    public class UserServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
