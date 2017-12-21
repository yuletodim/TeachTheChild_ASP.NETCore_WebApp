namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Downloads;

    public interface IDownloadMaterialsService
    {
        Task<DownloadDetailsModel> GetByIdAsync(int id);

        Task<IEnumerable<DownloadShortModel>> GetPortionAsync(int page, int pageSize, string type);

        Task<int> GetTotalCountAsync(string type);

        Task<string> GetPictureUrlAsync(int id);

        Task AddDownloadAsync(int id);

        Task<IEnumerable<DownloadShortModel>> GetLastThreeMost();
    }
}
