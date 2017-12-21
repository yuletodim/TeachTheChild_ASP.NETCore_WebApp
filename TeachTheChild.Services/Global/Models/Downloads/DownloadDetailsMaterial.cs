namespace TeachTheChild.Services.Global.Models.Downloads
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.DownloadMaterials;

    public class DownloadDetailsModel : IMapFrom<DownloadMaterial>
    {
        public int Id { get; set; }

        public string PictureUrl { get; set; }

        public int Downloads { get; set; }

        public DownloadMaterialType Type { get; set; }
    }
}
