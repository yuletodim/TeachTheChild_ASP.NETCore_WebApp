namespace TeachTheChild.Web.Areas.Moderator.Models.DownloadMaterials
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.DownloadMaterials;
    using TeachTheChild.Services.Moderator.Models.Downloads;

    public class DownloadsFormBindingModel : IMapFrom<DownloadsFormModel>, IMapTo<DownloadsFormModel>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public DownloadMaterialType Type { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }

}
