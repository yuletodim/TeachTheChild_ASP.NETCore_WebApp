namespace TeachTheChild.Services.Global.Models.Downloads
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.DownloadMaterials;

    public class DownloadShortModel : IMapFrom<DownloadMaterial>
    {
        public int Id { get; set; }

        public string PictureUrl { get; set; }
    }
}
