namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
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

        public async Task<IActionResult> LikeArticleAjax(int id, bool likeArticle)
        {
            var userId = this.userManager.GetUserId(this.User);

            var result = await this.articlesService.AddLikeAsync(userId, id, likeArticle);
            var likes = await this.articlesService.GetLikesByIdAsync(id);
            var dislikes = await this.articlesService.GetDislikesByIdAsync(id);

            return this.Json(new { success = result, likes = likes, dislikes = dislikes });
        }
    }
}
