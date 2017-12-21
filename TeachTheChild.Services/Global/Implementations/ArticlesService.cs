namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models.Articles;
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

        public async Task<bool> AddLikeAsync(string userId, int articleId, bool likeValue)
        {
            var like = await this.dbContext
                    .ArticleLikes
                    .Where(a => a.ArticleId == articleId && a.UserId == userId)
                    .FirstOrDefaultAsync();

            if (like != null && like.IsLike == likeValue)
            {
                return false;
            }
            else if(like != null)
            {
                like.IsLike = likeValue;
            }
            else
            {
                await this.dbContext.AddAsync(new ArticleLike
                {
                    ArticleId = articleId,
                    UserId = userId,
                    IsLike = likeValue
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentAsync(string userId, int articleId, string content, int baseCommentId = 0)
        {
            var article = await this.dbContext
                .Articles
                .FirstOrDefaultAsync(a => a.Id == articleId);

            if (article == null)
            {
                return false;
            }

            if (baseCommentId == 0)
            {
                article.Comments.Add(new ArticleComment { Content = content });
            }
            else
            {
                var comment = article.Comments.Where(c => c.Id == baseCommentId).FirstOrDefault();
                if (comment == null)
                {
                    return false;
                }

                comment.Answers.Add(new ArticleComment
                {
                    Content = content,
                    BaseCommentId = baseCommentId
                });
            }
         
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentLikeAsync(string userId, int articleCommentId, bool likeValue)
        {
            var like = await this.dbContext
                    .ArticleCommentLikes
                    .Where(a => a.ArticleCommentId == articleCommentId && a.UserId == userId)
                    .FirstOrDefaultAsync();

            if (like != null && like.IsLike == likeValue)
            {
                return false;
            }
            else if (like != null)
            {
                like.IsLike = likeValue;
            }
            else
            {
                await this.dbContext.AddAsync(new ArticleCommentLike
                {
                    ArticleCommentId = articleCommentId,
                    UserId = userId,
                    IsLike = likeValue
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetLikesByIdAsync(int id)
            => await this.dbContext
                .ArticleLikes
                .Where(a => a.ArticleId == id && a.IsLike == true)
                .CountAsync();

        public async Task<int> GetDislikesByIdAsync(int id)
            => await this.dbContext
                .ArticleLikes
                .Where(a => a.ArticleId == id && a.IsLike == false)
                .CountAsync();
    }
}
