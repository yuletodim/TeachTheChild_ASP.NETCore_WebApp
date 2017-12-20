namespace TeachTheChild.Services.Moderator.Models.Downloads
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.DownloadMaterials;

    public class DownloadsFormModel : IMapFrom<DownloadMaterial>, IMapTo<DownloadMaterial>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }

        public string PictureUrl { get; set; }

        public DownloadMaterialType Type { get; set; }
    }
}
