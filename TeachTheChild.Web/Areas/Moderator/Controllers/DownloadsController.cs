namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Services.Moderator.Contracts;

    public class DownloadsController : BaseModeratorControler
    {
        private IDownloadMaterialsModeratorService downloadsService;

        public DownloadsController(IDownloadMaterialsModeratorService downloadsService)
        {
            this.downloadsService = downloadsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
