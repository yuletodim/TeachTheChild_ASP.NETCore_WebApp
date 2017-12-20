namespace TeachTheChild.Web.Areas.Moderator.Models.Videos
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteVideoBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}
