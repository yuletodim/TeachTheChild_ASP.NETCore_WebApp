namespace TeachTheChild.Data.Models.DownloadMaterials
{
    using TeachTheChild.Data.Models.Common;

    public class DownloadMaterial : Material
    {
        public string PictureUrl { get; set; }

        public int Downloads { get; set; }

        public DownloadMaterialType Type { get; set; }
    }
}
