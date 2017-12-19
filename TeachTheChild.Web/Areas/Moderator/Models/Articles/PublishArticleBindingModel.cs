namespace TeachTheChild.Web.Areas.Moderator.Models.Articles
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Services.Moderator.Models.Articles;

    public class PublishArticleBindingModel : IMapTo<AddArticleModel>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }
    }
}
