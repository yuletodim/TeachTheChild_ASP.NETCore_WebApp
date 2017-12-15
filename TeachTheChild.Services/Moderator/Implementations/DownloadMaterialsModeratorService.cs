namespace TeachTheChild.Services.Moderator.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Moderator.Contracts;

    public class DownloadMaterialsModeratorService : IDownloadMaterialsModeratorService
    {
        private TeachTheChildDbContext dbContext;

        public DownloadMaterialsModeratorService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
