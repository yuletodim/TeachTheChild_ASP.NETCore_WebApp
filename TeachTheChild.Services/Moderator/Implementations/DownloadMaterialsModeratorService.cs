namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;

    public class DownloadMaterialsModeratorService : IDownloadMaterialsModeratorService
    {
        private TeachTheChildDbContext dbContext;

        public DownloadMaterialsModeratorService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
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
