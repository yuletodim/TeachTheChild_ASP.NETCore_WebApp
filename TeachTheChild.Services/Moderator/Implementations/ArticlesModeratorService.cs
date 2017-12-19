namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;

    public class ArticlesModeratorService : IArticlesModeratorService
    {
        private TeachTheChildDbContext dbContext;

        public ArticlesModeratorService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
