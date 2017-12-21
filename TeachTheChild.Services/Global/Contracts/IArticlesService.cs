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
    }
}
