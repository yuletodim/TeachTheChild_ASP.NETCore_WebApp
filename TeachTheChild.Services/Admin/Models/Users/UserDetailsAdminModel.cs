namespace TeachTheChild.Services.Admin.Models.Users
{
    using System;
    using AutoMapper;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models;

    public class UserDetailsAdminModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Roles { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile
                  .CreateMap<User, UserDetailsAdminModel>()
                  .ForMember(u => u.Country, opt => opt.MapFrom(u => u.Country.Name));
        }

    }
}
