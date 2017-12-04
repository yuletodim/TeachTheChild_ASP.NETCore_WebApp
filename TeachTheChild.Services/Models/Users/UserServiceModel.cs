namespace TeachTheChild.Services.Models.Users
{
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Mappings;

    public class UserServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
