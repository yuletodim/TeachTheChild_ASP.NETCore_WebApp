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
    using Microsoft.EntityFrameworkCore;

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
                    .ProjectTo<ArticleTableModeratorModel>()
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)                   
                    .ToList();

            return articlesModel;
        }

        public async Task<int> AddAsync(ArticleFormModel articleModel)
        {
            var article = this.mapper.Map<Article>(articleModel);

            await this.dbContext.Articles.AddAsync(article);
            await this.dbContext.SaveChangesAsync();

            return article.Id;
        }

        public async Task<bool> IsArticleFromUserAsync(int id, string userId)
            => await this.dbContext.Articles.AnyAsync(a => a.Id == id && a.UserId == userId);

        public async Task<ArticleFormModel> GetByIdAsync(int id)
        {
            var b = await this.dbContext
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleFormModel>()
                .FirstOrDefaultAsync();
            return b;
        }


        public async Task<bool> EditAsync(ArticleFormModel articleModel)
        {
            var article = this.dbContext.Articles.Find(articleModel.Id);
            if (article == null)
            {
                return false;
            }

            article.Title = articleModel.Title;
            article.Content = articleModel.Content;

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var article = await this.dbContext.Articles.FindAsync(id);

            if (article == null)
            {
                return false;
            }

            this.dbContext.Remove(article);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}
