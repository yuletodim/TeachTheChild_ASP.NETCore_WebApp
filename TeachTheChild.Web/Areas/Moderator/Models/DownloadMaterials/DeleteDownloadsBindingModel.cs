namespace TeachTheChild.Web.Areas.Moderator.Models.DownloadMaterials
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteDownloadsBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}
