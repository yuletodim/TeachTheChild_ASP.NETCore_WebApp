namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models.Books;

    public class BooksService : IBooksService
    {
        private TeachTheChildDbContext dbContext;

        public BooksService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BookDetailsModel> GetByIdAsync(int id)
            => await this.dbContext
                .Books
                .Where(a => a.Id == id)
                .ProjectTo<BookDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookShortModel>> GetLastTreeAsync()
            => await this.dbContext
                .Books
                .OrderByDescending(a => a.CreatedOn)
                .Skip(0)
                .Take(3)
                .ProjectTo<BookShortModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookShortModel>> GetPortionAsync(int page, int pageSize)
            => await this.dbContext
                .Books
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BookShortModel>()
                .ToListAsync();

        public async Task<int> GetTotalCountAsync()
            => await this.dbContext
                .Books
                .CountAsync();

        public async Task<bool> AddLikeAsync(string userId, int bookId, bool likeValue)
        {
            var like = await this.dbContext
                    .BookLikes
                    .Where(b => b.BookId == bookId && b.UserId == userId)
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
                await this.dbContext.AddAsync(new BookLike
                {
                    BookId = bookId,
                    UserId = userId,
                    IsLike = likeValue
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentAsync(string userId, int bookId, string content, int? baseCommentId = null)
        {
            var book = await this.dbContext
                .Books
                .FirstOrDefaultAsync(a => a.Id == bookId);

            if (book == null)
            {
                return false;
            }

            if (baseCommentId == null)
            {
                book.Comments.Add(new BookComment
                {
                    UserId = userId,
                    Content = content
                });
            }
            else
            {
                var comment = book.Comments.Where(c => c.Id == baseCommentId).FirstOrDefault();
                if (comment == null)
                {
                    return false;
                }

                comment.Answers.Add(new BookComment
                {
                    UserId = userId,
                    Content = content,
                    BaseCommentId = baseCommentId
                });
            }


            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentLikeAsync(string userId, int bookCommentId, bool likeValue)
        {
            var like = await this.dbContext
                    .BookCommentLikes
                    .Where(b => b.BookCommentId == bookCommentId && b.UserId == userId)
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
                await this.dbContext.AddAsync(new BookCommentLike
                {
                    BookCommentId = bookCommentId,
                    UserId = userId,
                    IsLike = likeValue
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetLikesByIdAsync(int id)
            => await this.dbContext
                    .BookLikes
                    .Where(b => b.BookId == id && b.IsLike == true)
                    .CountAsync();

        public async Task<int> GetDislikesByIdAsync(int id)
            => await this.dbContext
                    .BookLikes
                    .Where(b => b.BookId == id && b.IsLike == false)
                    .CountAsync();
    }
}

