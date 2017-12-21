﻿namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Downloads;

    public interface IDownloadMaterialsService
    {
        Task<DownloadDetailsModel> GetByIdAsync(int id);

        Task<IEnumerable<DownloadShortModel>> GetPortionAsync(int page, int pageSize);

        Task<int> GetTotalCountAsync();

        Task<string> GetPictureUrlAsync(int id);

        Task AddDownloadAsync(int id);
    }
}
