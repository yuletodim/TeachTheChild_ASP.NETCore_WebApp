namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Articles;

    public interface IArticlesService
    {
        Task<IEnumerable<ArticleShortModel>> GetLastTreeAsync();

        Task<ArticleDetailsModel> GetByIdAsync(int id);

        Task<IEnumerable<ArticleShortModel>> GetPortionAsync(int page, int pageSize);

        Task<int> GetTotalCountAsync();

        Task<bool> AddLikeAsync(string userId, int articleId, bool likeValue);

        Task<bool> AddCommentAsync(string userId, int articleId, string content, int? baseCommentId = null);

        Task<bool> AddCommentLikeAsync(string userId, int articleCommentId, bool likeValue);

        Task<int> GetLikesByIdAsync(int id);

        Task<int> GetDislikesByIdAsync(int id);
    }
}
