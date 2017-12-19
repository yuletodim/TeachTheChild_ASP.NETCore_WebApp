namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Articles;
    using System.Threading.Tasks;
    using AutoMapper;
    using TeachTheChild.Data.Models.Articles;

    public class ArticlesModeratorService : IArticlesModeratorService
    {
        private readonly TeachTheChildDbContext dbContext;
        private readonly IMapper mapper;

        public ArticlesModeratorService(TeachTheChildDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<ArticleTableModeratorModel> GetFilteredPortion(
            int length, 
            int start, 
            string sortCol, 
            string sortDir, 
            string search, 
            out int count)
        {
            var articles = this.dbContext
                .Articles
                .Where(u => search == null
                || u.Title.ToLower().Contains(search.ToLower())
                || u.User.Name.ToLower().Contains(search.ToLower())
                || u.CreatedOn.ToString().ToLower().Contains(search.ToLower()));

            count = articles.Count();

            var articlesModel = articles
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)
                    .ProjectTo<ArticleTableModeratorModel>()
                    .ToList();

            return articlesModel;
        }

        public async Task<bool> AddAsync(AddArticleModel articleModel)
        {
            var article = this.mapper.Map<Article>(articleModel);

            await this.dbContext.Articles.AddAsync(article);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}
