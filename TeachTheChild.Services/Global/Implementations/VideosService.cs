namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models.Videos;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models.Videos;

    public class VideosService : IVideosService
    {
        private TeachTheChildDbContext dbContext;

        public VideosService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VideoDetailsModel> GetMostLikedAsync()
        {
            var videos = await this.dbContext
                .Videos
                .OrderBy(a => a.Likes.Count)
                .ThenByDescending(v => v.CreatedOn)
                .Take(1)
                .ProjectTo<VideoDetailsModel>()
                .ToListAsync();

            return videos.FirstOrDefault();
        }

        public async Task<int> GetTotalCountAsync()
            => await this.dbContext
                .Videos
                .CountAsync();

        public async Task<VideoDetailsModel> GetByIdAsync(int? id = null)
        {
            var query = this.dbContext.Videos.AsQueryable();

            if (id.HasValue)
            {
                return await query
                    .Where(a => a.Id == id)
                    .ProjectTo<VideoDetailsModel>()
                    .FirstOrDefaultAsync();
            }
            else
            {
                return await query
                    .OrderByDescending(v => v.CreatedOn)
                    .ProjectTo<VideoDetailsModel>()
                    .FirstOrDefaultAsync();
            }             
        }

        public async Task<IEnumerable<VideoShortModel>> GetPortionAsync(int page, int pageSize)
            => await this.dbContext
                .Videos
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<VideoShortModel>()
                .ToListAsync();

        public async Task<bool> AddLikeAsync(string userId, int videoId, bool likeValue)
        {
            var like = await this.dbContext
                    .VideoLikes
                    .Where(v => v.VideoId == videoId && v.UserId == userId)
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
                await this.dbContext.AddAsync(new VideoLike
                {
                    VideoId = videoId,
                    UserId = userId,
                    IsLike = likeValue
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentAsync(string userId, int videoId, string content, int baseCommentId = 0)
        {
            var video = await this.dbContext
                .Videos
                .FirstOrDefaultAsync(a => a.Id == videoId);

            if (video == null)
            {
                return false;
            }

            if (baseCommentId == 0)
            {
                video.Comments.Add(new VideoComment { Content = content });
            }
            else
            {
                var comment = video.Comments.Where(c => c.Id == baseCommentId).FirstOrDefault();
                if (comment == null)
                {
                    return false;
                }

                comment.Answers.Add(new VideoComment
                {
                    Content = content,
                    BaseCommentId = baseCommentId
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentLikeAsync(string userId, int videoCommentId, bool likeValue)
        {
            var like = await this.dbContext
                    .VideoCommentLikes
                    .Where(vc => vc.VideoCommentId == videoCommentId && vc.UserId == userId)
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
                await this.dbContext.AddAsync(new VideoCommentLike
                {
                    VideoCommentId = videoCommentId,
                    UserId = userId,
                    IsLike = likeValue
                });
            }

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetLikesByIdAsync(int id)
            => await this.dbContext
                .VideoLikes
                .Where(v => v.VideoId == id && v.IsLike == true)
                .CountAsync();

        public async Task<int> GetDislikesByIdAsync(int id)
            => await this.dbContext
                .VideoLikes
                .Where(v => v.VideoId == id && v.IsLike == false)
                .CountAsync();
    }
}

