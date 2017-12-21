namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Videos;

    public interface IVideosService
    {
        Task<VideoDetailsModel> GetMostLikedAsync();

        Task<int> GetTotalCountAsync();

        Task<VideoDetailsModel> GetByIdAsync(int? id = null);

        Task<IEnumerable<VideoShortModel>> GetPortionAsync(int page, int pageSize);

        Task<bool> AddLikeAsync(string userId, int videoId, bool likeValue);

        Task<bool> AddCommentAsync(string userId, int videoId, string content, int baseCommentId = 0);

        Task<bool> AddCommentLikeAsync(string userId, int videoCommentId, bool likeValue);

        Task<int> GetLikesByIdAsync(int id);

        Task<int> GetDislikesByIdAsync(int id);
    }
}
