namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
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
            =>  await this.dbContext
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleDetailsModel>()
                .FirstOrDefaultAsync();


        public async Task<IEnumerable<ArticleShortModel>> GetPortionAsync(int page, int pageSize)
            => await this.dbContext
                .Articles
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ArticleShortModel>()
                .ToListAsync();

        public async Task<int> GetTotalCountAsync()
            => await this.dbContext
                .Articles
                .CountAsync();
    }
}
