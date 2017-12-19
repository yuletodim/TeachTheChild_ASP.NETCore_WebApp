namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Downloads;

    public class DownloadMaterialsModeratorService : IDownloadMaterialsModeratorService
    {
        private readonly TeachTheChildDbContext dbContext;
        private readonly IMapper mapper;

        public DownloadMaterialsModeratorService(TeachTheChildDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<DownloadsTableModeratorModel> GetFilteredPortion(
            int length, 
            int start, 
            string sortCol, 
            string sortDir, 
            string search, 
            out int count)
        {
            var downloads = this.dbContext
                .DownloadMaterials
                .Where(d => search == null
                || d.User.Name.ToLower().Contains(search.ToLower())
                || d.CreatedOn.ToString().ToLower().Contains(search.ToLower()));

            count = downloads.Count();

            var downloadsModel = downloads
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)
                    .ProjectTo<DownloadsTableModeratorModel>()
                    .ToList();

            return downloadsModel;
        }
    }
}
