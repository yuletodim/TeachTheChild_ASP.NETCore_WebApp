namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
        



    }
}
