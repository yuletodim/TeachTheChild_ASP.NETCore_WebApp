namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models;
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

        [HttpPost]
        public async Task<IActionResult> LikeVideoAjax([FromBody]LikeFormBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { success = false });
            }

            var userId = this.userManager.GetUserId(this.User);

            var result = await this.videosService.AddLikeAsync(userId, model.Id, model.IsLike);
            var likes = await this.videosService.GetLikesByIdAsync(model.Id);
            var dislikes = await this.videosService.GetDislikesByIdAsync(model.Id);

            return this.Json(new { success = result, likes = likes, dislikes = dislikes });
        }

        public async Task<IActionResult> AddCommentAjax(CommentFormBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { success = false });
            }

            var userId = this.userManager.GetUserId(this.User);
            var result = await this.videosService.AddCommentAsync(userId, model.Id, model.Content, model.CommentId);

            return this.Json(new { success = result });
        }
    }
}
