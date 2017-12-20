namespace TeachTheChild.Web.Areas.Moderator.Models.Articles
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Services.Moderator.Models.Articles;

    public class PublishArticleBindingModel : IMapTo<ArticleFormModel>, IMapFrom<ArticleFormModel>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }
    }
}
