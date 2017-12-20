namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models.Articles;

    public class ArticlesService : IArticlesService
    {
        private TeachTheChildDbContext dbContext;

        public ArticlesService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleShortModel>> GetLastTreeAsync()
            => await this.dbContext
                .Articles
                .OrderByDescending(a => a.CreatedOn)
                .Skip(0)
                .Take(3)
                .ProjectTo<ArticleShortModel>()
                .ToListAsync();


        public async Task<ArticleDetailsModel> GetByIdAsync(int id)
        {
            var b =  await this.dbContext
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleDetailsModel>()
                .FirstOrDefaultAsync();

            return b;
        }


    }
}
