namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Videos;

    public interface IVideosService
    {
        Task<VideoShortModel> GetMostLikedAsync();

        Task<int> GetTotalCountAsync();

        Task<VideoDetailsModel> GetByIdAsync(int? id = null);

        Task<IEnumerable<VideoShortModel>> GetPortionAsync(int page, int pageSize);
    }
}
