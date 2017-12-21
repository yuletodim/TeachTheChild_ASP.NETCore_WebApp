namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models.Downloads;

    public class DownloadsController : BaseController
    {
        private readonly IDownloadMaterialsService downloadsService;
        private readonly IHostingEnvironment hostingEnvironment;

        public DownloadsController(IDownloadMaterialsService downloadsService, IHostingEnvironment hostingEnvironment)
        {
            this.downloadsService = downloadsService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(int page = 1, string type = null)
        {
            var downloads = await this.downloadsService.GetPortionAsync(page, WebConstants.DownloadsPageSize, type);
            var pagesCount = (int)Math.Ceiling(await this.downloadsService.GetTotalCountAsync(type) / (double)WebConstants.DownloadsPageSize);

            var data = new DownloadsPagingViewModel
            {
                Downloads = downloads,
                CurrentPage = page,
                PagesCount = pagesCount,
                Type = type
            };

            return View(data);
        }

        public async Task<IActionResult> GetAjax(int id)
        {
            var download = await this.downloadsService.GetByIdAsync(id);

            return this.PartialView("_DownloadDetailsPartial", download);
        }

        public async Task<IActionResult> Download(int id)
        {
            var pictureUrl = await this.downloadsService.GetPictureUrlAsync(id);

            if (pictureUrl == null)
            {
                return this.BadRequest();
            }

            var path = $"{this.hostingEnvironment.WebRootPath}{pictureUrl}";

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            await this.downloadsService.AddDownloadAsync(id);

            return File(
                memory, 
                WebConstants.ImageType, 
                $"{Path.GetFileName(path).Substring(0, 6)}_{DateTime.UtcNow.ToShortDateString()}{Path.GetFileName(path).Substring(Path.GetFileName(path).LastIndexOf('.'))}");
        }
    }
}
