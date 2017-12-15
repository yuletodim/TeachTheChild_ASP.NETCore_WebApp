namespace TeachTheChild.Services.Global.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;

    public class DownloadMaterialsService : IDownloadMaterialsService
    {
        private TeachTheChildDbContext dbContext;

        public DownloadMaterialsService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
