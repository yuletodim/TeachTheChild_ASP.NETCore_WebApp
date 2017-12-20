namespace TeachTheChild.Services.Moderator.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Moderator.Models.Articles;

    public interface IArticlesModeratorService
    {
        IEnumerable<ArticleTableModeratorModel> GetFilteredPortion(
            int length, 
            int start, 
            string sortCol, 
            string sortDir, 
            string search, 
            out int count);

        Task<int> AddAsync(ArticleFormModel article);

        Task<bool> IsArticleFromUserAsync(int id, string userId);

        Task<ArticleFormModel> GetByIdAsync(int id);

        Task<bool> EditAsync(ArticleFormModel article);

        Task<bool> DeleteAsync(int id);
    }
}
