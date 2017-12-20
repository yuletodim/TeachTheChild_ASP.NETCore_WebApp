namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Services.Global.Contracts;

    public class DownloadsController : BaseController
    {
        private readonly IDownloadMaterialsService downloadsService;

        public DownloadsController(IDownloadMaterialsService downloadsService)
        {
            this.downloadsService = downloadsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
