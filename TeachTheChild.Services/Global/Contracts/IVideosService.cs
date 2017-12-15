namespace TeachTheChild.Services.Global.Contracts
{
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Videos;

    public interface IVideosService
    {
        Task<VideoShortModel> GetMostLiked();
    }
}
