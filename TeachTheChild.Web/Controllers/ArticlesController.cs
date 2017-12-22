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
    using TeachTheChild.Web.Models.Articles;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;
        private readonly UserManager<User> userManager;

        public ArticlesController(IArticlesService articlesService, UserManager<User> userManager)
        {
            this.articlesService = articlesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var articles = await this.articlesService.GetPortionAsync(page, WebConstants.ArticlesPageSize);
            var pagesCount = (int)Math.Ceiling(await this.articlesService.GetTotalCountAsync() / (double)WebConstants.ArticlesPageSize);

            var data = new ArticlesPagingViewModel
            {
                Articles = articles,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
            => this.View(await this.articlesService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> LikeArticleAjax([FromBody]LikeFormBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { success = false });
            }

            var userId = this.userManager.GetUserId(this.User);

            var result = await this.articlesService.AddLikeAsync(userId, model.Id, model.IsLike);
            var likes = await this.articlesService.GetLikesByIdAsync(model.Id);
            var dislikes = await this.articlesService.GetDislikesByIdAsync(model.Id);

            return this.Json(new { success = result, likes = likes, dislikes = dislikes });
        }

        public async Task<IActionResult> AddCommentAjax(CommentFormBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { success = false });
            }

            var userId = this.userManager.GetUserId(this.User);
            var result = await this.articlesService.AddCommentAsync(userId, model.Id, model.Content, model.CommentId);

            return this.Json(new { success = result });
        }
    }
}
