namespace TeachTheChild.Services.Moderator.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Moderator.Models.Videos;

    public interface IVideosModeratorService
    {
        IEnumerable<VideoTableModeratorModel> GetFilteredPortion(
            int length,
            int start,
            string sortCol,
            string sortDir,
            string search,
            out int count);

        Task<bool> DeleteAsync(int id);

        Task<int> AddAsync(VideoFormModel videoModel);

        Task<string> GetUrlByIdAsync(int id);
    }
}
