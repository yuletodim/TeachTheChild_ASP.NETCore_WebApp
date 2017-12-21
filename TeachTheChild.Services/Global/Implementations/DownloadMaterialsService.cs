namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models.Downloads;
    using System.Collections.Generic;

    public class DownloadMaterialsService : IDownloadMaterialsService
    {
        private TeachTheChildDbContext dbContext;

        public DownloadMaterialsService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DownloadDetailsModel> GetByIdAsync(int id)
            => await this.dbContext
                .DownloadMaterials
                .Where(d => d.Id == id)
                .ProjectTo<DownloadDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<DownloadShortModel>> GetPortionAsync(int page, int pageSize, string type)
            => await this.dbContext
                .DownloadMaterials
                .Where(d => type == null || type.ToLower() == d.Type.ToString().ToLower())
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<DownloadShortModel>()
                .ToListAsync();

        public async Task<int> GetTotalCountAsync(string type)
            => await this.dbContext
                .DownloadMaterials
                .Where(d => type == null || d.Type.ToString().ToLower() == type.ToLower())
                .CountAsync();

        public async Task<string> GetPictureUrlAsync(int id)
            => await this.dbContext
                .DownloadMaterials
                .Where(d => d.Id == id)
                .Select(d => d.PictureUrl)
                .FirstOrDefaultAsync();

        public async Task AddDownloadAsync(int id)
        {
            var download = await this.dbContext.DownloadMaterials.FindAsync(id);

            if (download != null)
            {
                download.Downloads++;
                await this.dbContext.SaveChangesAsync();
            }  
        }

        public async Task<IEnumerable<DownloadShortModel>> GetLastThreeMost()
            => await this.dbContext
                .DownloadMaterials
                .OrderByDescending(p => p.Id)
                .Take(3)
                .ProjectTo<DownloadShortModel>()
                .ToListAsync();
    }
}
