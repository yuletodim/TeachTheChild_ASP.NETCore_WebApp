namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models.Videos;

    public class VideosController : BaseController
    {
        private readonly IVideosService videosService;

        public VideosController(IVideosService videosService)
        {
            this.videosService = videosService;
        }

        public async Task<IActionResult> Index(int page = 1, int? videoId = null)
        {
            var video = await this.videosService.GetByIdAsync(videoId);
            var videos = await this.videosService.GetPortionAsync(page, WebConstants.VideosPageSize);
            var pagesCount = (int)Math.Ceiling(await this.videosService.GetTotalCountAsync() / (double)WebConstants.VideosPageSize);

            var data = new VideosPagingViewModel
            {
                Video = video,
                Videos = videos,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return View(data);
        }
    }
}
