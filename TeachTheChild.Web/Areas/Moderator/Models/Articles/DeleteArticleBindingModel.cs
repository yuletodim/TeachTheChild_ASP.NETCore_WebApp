namespace TeachTheChild.Web.Areas.Moderator.Models.Articles
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteArticleBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}
