namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models.Videos;

    public class VideosController : BaseController
    {
        private readonly IVideosService videosService;
        private readonly UserManager<User> userManager;

        public VideosController(IVideosService videosService, UserManager<User> userManager)
        {
            this.videosService = videosService;
            this.userManager = userManager;
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

        public async Task<IActionResult> LikeVideoAjax(int id, bool likeVideo)
        {
            var userId = this.userManager.GetUserId(this.User);

            var result = await this.videosService.AddLikeAsync(userId, id, likeVideo);
            var likes = await this.videosService.GetLikesByIdAsync(id);
            var dislikes = await this.videosService.GetDislikesByIdAsync(id);

            return this.Json(new { success = result, likes = likes, dislikes = dislikes });
        }
    }
}
