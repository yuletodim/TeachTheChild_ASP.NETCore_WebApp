namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
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
    }
}
