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
    using TeachTheChild.Services.Global.Models.Videos;

    public class VideosService : IVideosService
    {
        private TeachTheChildDbContext dbContext;

        public VideosService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VideoShortModel> GetMostLikedAsync()
        {
            var videos = await this.dbContext
                .Videos
                .OrderBy(a => a.Likes.Count)
                .ThenByDescending(v => v.CreatedOn)
                .Take(1)
                .ProjectTo<VideoShortModel>()
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

    }
}
