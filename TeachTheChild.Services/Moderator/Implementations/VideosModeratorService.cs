namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Videos;

    public class VideosModeratorService : IVideosModeratorService
    {
        private readonly TeachTheChildDbContext dbContext;
        private readonly IMapper mapper;

        public VideosModeratorService(TeachTheChildDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<VideoTableModeratorModel> GetFilteredPortion(
            int length, 
            int start, 
            string sortCol, 
            string sortDir, 
            string search, 
            out int count)
        {
            var videos = this.dbContext
                .Videos
                .Where(v => search == null
                || v.Title.ToLower().Contains(search.ToLower())
                || v.User.Name.ToLower().Contains(search.ToLower())
                || v.Source.ToLower().Contains(search.ToLower())
                || v.CreatedOn.ToString().ToLower().Contains(search.ToLower()));

            count = videos.Count();

            var videosModel = videos
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)
                    .ProjectTo<VideoTableModeratorModel>()
                    .ToList();

            return videosModel;
        }
    }
}
