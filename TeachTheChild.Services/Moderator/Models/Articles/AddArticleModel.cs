namespace TeachTheChild.Services.Moderator.Models.Articles
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Articles;

    public class AddArticleModel : IMapTo<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }
    }
}
