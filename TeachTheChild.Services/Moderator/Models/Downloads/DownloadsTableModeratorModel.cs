namespace TeachTheChild.Services.Moderator.Models.Downloads
{
    using System;
    using AutoMapper;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.DownloadMaterials;

    public class DownloadsTableModeratorModel : IMapFrom<DownloadMaterial>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Downloads { get; set; }

        public DownloadMaterialType Type { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<DownloadMaterial, DownloadsTableModeratorModel>()
                .ForMember(d => d.User, opt => opt.MapFrom(d => d.User.Name));
        }
    }
}
